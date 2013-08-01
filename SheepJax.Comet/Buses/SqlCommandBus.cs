using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using SheepJax.Comet.AsyncHelpers;
using SheepJax.Comet.DataHelpers;

namespace SheepJax.Comet.Buses
{
    public class SqlCommandBus: ICommandBus
    {
        private readonly ILog _logger = LogManager.GetLogger<SqlCommandBus>();

        private readonly Func<SqlConnection> _connectionFactory;
        private readonly LinkedList<SqlCommandMessage> _cache = new LinkedList<SqlCommandMessage>();

        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly LazyPublisher<SqlCommandMessage> _messageAdded;
        private static readonly TimeSpan PollDbInterval = TimeSpan.FromMilliseconds(400);
        private static readonly TimeSpan DbGcInterval = TimeSpan.FromSeconds(10);
        private byte[] _lastTimestamp = null;

        private static readonly TimeSpan CollectGarbageInterval = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan MessageExpiry = TimeSpan.FromSeconds(120);
        
        private static SqlConnection GetConnection(string connectionName)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }

        public SqlCommandBus(string connectionName)
            :this(()=> GetConnection(connectionName))
        {
            new Timer(_ => CollectGarbage(), null, CollectGarbageInterval, TimeSpan.FromTicks(-1));
        }

        public SqlConnection OpenConnection()
        {
            var conn = _connectionFactory();
            conn.Open();
            return conn;
        }

        private void CollectGarbage()
        {
            var node = _cache.First;
            var now = DateTime.Now;
            while (node != null && now - node.Value.CreatedUtcTime > MessageExpiry)
            {
                var nextNode = node.Next;
                _cache.Remove(node);
                node = nextNode;
            }
        }


        private Task _pollDbTask = TplHelper.Empty;
        private Task _dbGcTask = TplHelper.Empty;
        public SqlCommandBus(Func<SqlConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _messageAdded = new LazyPublisher<SqlCommandMessage>(observer=>
                {
                    var isDisposed = false;
                    _pollDbTask = _pollDbTask.ContinueWith(t => TplHelper.DoWhile(() => PollDb(observer).ThenDelay(PollDbInterval), _ => !isDisposed)).Unwrap();
                    _dbGcTask = _dbGcTask.ContinueWith(t => TplHelper.DoWhile(() => DbGc().ThenDelay(DbGcInterval), _ => !isDisposed)).Unwrap();
                    return Disposable.Create(() => isDisposed = true);
                });
        }

        protected virtual Task DbGc()
        {
            const string sql = "delete SheepJaxMessages where CreatedUtcTime < dateadd(minute, -10, GetUtcDate())";

            return _connectionFactory().WithinTransaction(tx =>
                TplHelper.Using(new SqlCommand(sql, tx.Connection, tx), cmd =>
                    cmd.ExecuteNonQueryAsync().Success(_ => tx.Commit())
                )
            ).Catch(_logger);
        }

        protected virtual Task PollDb(IObserver<SqlCommandMessage> observer)
        {
            const string sql = "select ClientId, Message, CreatedUtcTime, Timestamp from SheepJaxMessages where CreatedUtcTime > dateadd(minute, -10, GetUtcDate())";

            return _connectionFactory().WithinTransaction(tx =>
                TplHelper.Using(new SqlCommand(sql, tx.Connection, tx), cmd =>
                {
                    if (_lastTimestamp != null)
                    {
                        cmd.CommandText += " and timestamp > @lastTimestamp";
                        cmd.Parameters.Add(new SqlParameter("lastTimestamp", _lastTimestamp));
                    }
                    cmd.CommandText += " order by timestamp asc";
                    return cmd.ExecuteReaderAsync()
                        .Select(reader =>
                        {
                            using (reader)
                                while (reader.Read())
                                {
                                    var timestamp = _lastTimestamp = new byte[8];
                                    reader.GetBytes(3, 0, timestamp, 0, 8);
                                    var msg = new SqlCommandMessage
                                                    {
                                                        ClientId = reader.GetGuid(0),
                                                        Message = reader.GetString(1),
                                                        CreatedUtcTime = reader.GetDateTime(2),
                                                        Timestamp = timestamp
                                                    };
                                    using (_cacheLock.BeginWriteLock())
                                    {
                                        _cache.AddLast(msg);
                                        observer.OnNext(msg);
                                    }
                                }
                        });
                })
            ).Catch(_logger);
          }

        private void SendMessage(Guid clientId, string msg)
        {
            const string sql = "insert into SheepJaxMessages (ClientId, Message) values (@clientId, @message)";
            Task.Factory.StartNew(delegate
            {
                _connectionFactory().WithinTransaction(tx =>
                    TplHelper.Using(new SqlCommand(sql, tx.Connection, tx)
                        {
                            Parameters = {
                                        new SqlParameter("clientId", clientId),
                                        new SqlParameter("message", msg)
                                    }
                        },
                        cmd => cmd.ExecuteNonQueryAsync().Finally(t => tx.Commit())
                     )
                 );
            }).Catch(_logger);
        }

        public virtual IObservable<CommandMessage> GetObservable(Guid clientId)
        {
            return GetObservable()
                .Where(x=> x.ClientId == clientId);
        }

        private IObservable<SqlCommandMessage> GetObservable()
        {
            return Observable.Create<SqlCommandMessage>(obs =>
                {
                    LinkedListNode<SqlCommandMessage> lastNode = null;
                    while (true)
                    {
                        for (var next = (lastNode == null) ? _cache.First : lastNode.Next; next != null; next = next.Next)
                        {
                            obs.OnNext(next.Value);
                            lastNode = next;
                        }

                        if (!_cacheLock.TryEnterReadLock(10)) continue;
                        try
                        {
                            if (_cache.Last == lastNode)
                                return _messageAdded.Subscribe(obs);
                        }
                        finally { _cacheLock.ExitReadLock(); }
                    }
                });
        }

        public virtual Task Consumed(CommandMessage last)
        {
            var msg = last as SqlCommandMessage;
            if(msg == null)
                return TplHelper.Empty;

            const string sql = "delete SheepJaxMessages where ClientId=@clientId and timestamp<@timestamp";
            var dbTask =_connectionFactory().WithinTransaction(tx => 
                TplHelper.Using(new SqlCommand(sql, tx.Connection, tx)
                {
                    Parameters = {
                                    new SqlParameter("clientId", msg.ClientId), 
                                    new SqlParameter("timestamp", msg.Timestamp)}
                }
                , cmd=> cmd.ExecuteNonQueryAsync().Finally(_=> tx.Commit())
                )
            ).Catch(_logger);

            using (_cacheLock.BeginUpgradeableReadLock())
            {
                var node = _cache.Last;
                while (node != null && node.Value != last)
                    node = node.Previous;

                using (_cacheLock.BeginWriteLock())
                {
                    while (node != null)
                    {
                        var previousNode = node.Previous;
                        while (previousNode != null && previousNode.Value.ClientId != node.Value.ClientId)
                            previousNode = previousNode.Previous;

                        node.List.Remove(node);
                        node = previousNode;
                    }
                }
            }
            return dbTask;
        }

        public virtual IObserver<string> GetObserver(Guid clientId)
        {
            return Observer.Create<string>(msg => SendMessage(clientId, msg));
        }

        protected class SqlCommandMessage : CommandMessage
        {
            public byte[] Timestamp { get; set; }
        }
    }
}