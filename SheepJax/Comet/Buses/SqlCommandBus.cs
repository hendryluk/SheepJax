using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.AsyncHelpers;
using SheepJax.DataHelpers;

namespace SheepJax.Comet.Buses
{
    public class SqlCommandBus: ICommandBus
    {
        private readonly Func<SqlConnection> _connectionFactory;
        private readonly LinkedList<SqlCommandMessage> _cache = new LinkedList<SqlCommandMessage>();

        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly LazyPublisher<SqlCommandMessage> _messageAdded;
        private static readonly TimeSpan PollDbInterval = TimeSpan.FromMilliseconds(400);
        private static readonly TimeSpan DbGcInterval = TimeSpan.FromSeconds(10);
        private byte[] _lastTimestamp = null;

        private static SqlConnection GetConnection(string connectionName)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
        }

        public SqlCommandBus(string connectionName)
            :this(()=> GetConnection(connectionName))
        {    
        }

        public SqlCommandBus(Func<SqlConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _messageAdded = new LazyPublisher<SqlCommandMessage>(observer=>
                {
                    var isDisposed = false;
                    TplHelper.DoWhile(() => PollDb(observer).Delay(PollDbInterval), _=> !isDisposed);
                    TplHelper.DoWhile(() => DbGc().Delay(DbGcInterval), _=> !isDisposed);
                    return Disposable.Create(() => isDisposed = true);
                });
        }

        private Task DbGc()
        {
            const string disposeOld = "delete SheepJaxMessages where CreatedUtcTime < dateadd(minute, -10, GetUtcDate())";

            var con = _connectionFactory();
            return con.WithinTransaction(tx => new SqlCommand(disposeOld, con, tx).ExecuteNonQueryAsync());
        }

        private Task PollDb(IObserver<SqlCommandMessage> observer)
        {
            const string sql = "select MessageId, ClientId, Message, Timestamp from SheepJaxMessages where CreatedUtcTime > dateadd(minute, -10, GetUtcDate())";

            return _connectionFactory().WithinTransaction(tx =>
            {
                var cmd = new SqlCommand(sql, tx.Connection, tx);
                if (_lastTimestamp != null)
                {
                    cmd.CommandText += " and timestamp > @lastTimestamp";
                    cmd.Parameters.Add(new SqlParameter("lastTimestamp", _lastTimestamp));
                }
                cmd.CommandText += " order by timestamp asc";
                return cmd.ExecuteReaderAsync().Catch()
                    .Select(reader =>
                    {
                        using(reader)
                        using(_cacheLock.BeginWriteLock())
                        {
                            while (reader.Read())
                            {
                                var timestamp = _lastTimestamp = new byte[8];
                                reader.GetBytes(3, 0, timestamp, 0, 8);
                                var msg = new SqlCommandMessage
                                                {
                                                    MessageId = reader.GetGuid(0),
                                                    ClientId = reader.GetGuid(1),
                                                    Message = reader.GetString(2),
                                                    Timestamp = timestamp
                                                };
                                _cache.AddLast(msg);
                                observer.OnNext(msg);
                            }
                        }
                    });
            });
          }

        private void SendMessage(Guid clientId, string msg)
        {
            const string sql = "insert into SheepJaxMessages (MessageId, ClientId, Message) values (@messageId, @clientId, @message)";
            _connectionFactory().WithinTransaction(tx => 
                new SqlCommand(sql, tx.Connection, tx)
                    {
                        Parameters = {
                                        new SqlParameter("messageId", Guid.NewGuid()),
                                        new SqlParameter("clientId", clientId),
                                        new SqlParameter("message", msg)
                                    }
                    }.ExecuteNonQueryAsync()
                    .ContinueWith(t => tx.Commit()));
        }

        public IObservable<CommandMessage> GetObservable(Guid clientId)
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
                            Trace.WriteLine("Pushing from cache: " + next.Value.MessageId);
                            obs.OnNext(next.Value);
                            lastNode = next;
                        }

                        if (!_cacheLock.TryEnterReadLock(50)) continue;
                        try
                        {
                            if (_cache.Last == lastNode)
                                return _messageAdded.Subscribe(obs);
                        }
                        finally { _cacheLock.ExitReadLock(); }
                    }
                });
        }

        public Task Consumed(CommandMessage last)
        {
            var msg = last as SqlCommandMessage;
            if(msg == null)
                return TplHelper.Empty;

            const string sql = "delete SheepJaxMessages where ClientId=@clientId and timestamp<@timestamp";
            var dbTask =_connectionFactory().WithinTransaction(tx => 
                new SqlCommand(sql, tx.Connection, tx)
                {
                    Parameters = {
                                    new SqlParameter("clientId", msg.ClientId), 
                                    new SqlParameter("timestamp", msg.Timestamp)}
                }.ExecuteNonQueryAsync());

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


        private void ScheduleForGc(Guid pollId, LinkedListNode<SqlCommandMessage> node)
        {
            if (node == null)
                return;

            node = node.Previous;
            Task.Factory.StartNew(() =>
                    {
                        while (node != null)
                        {
                            var previousNode = node.Previous;
                            for (;
                                previousNode != null && previousNode.Value.ClientId != pollId;
                                previousNode = previousNode.Previous) ;

                            node.List.Remove(node);
                            node = previousNode;
                        }
                    });
        }

        private static LinkedListNode<T> FindNext<T>(LinkedListNode<T> node, Func<T, bool> predicate)
        {
            while(node != null)
            {
                if (predicate(node.Value))
                    return node;
                node = node.Next;
            }
            return null;
        }

        public IObserver<string> GetObserver(Guid clientId)
        {
            return Observer.Create<string>(msg => SendMessage(clientId, msg));
        }

        

        private class SqlCommandMessage : CommandMessage
        {
            public byte[] Timestamp { get; set; }
        }
    }
}