﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using SheepJax.RxHelpers;
using SheepJax.DataHelpers;
using System.Linq;

namespace SheepJax.Comet.Buses
{
    public class SqlCommandBus: ICommandBus
    {
        private readonly Func<SqlConnection> _connectionFactory;
        private readonly LinkedList<SqlCommandMessage> _cache = new LinkedList<SqlCommandMessage>();

        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly LazyPublisher<SqlCommandMessage> _messageAdded;
        private readonly Dictionary<Guid, SqlCommandMessage> _gcSubjects = new Dictionary<Guid, SqlCommandMessage>();
        private static readonly TimeSpan PollDbInterval = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan DbGcInterval = TimeSpan.FromSeconds(10);
        private byte[] _lastTimestamp = null;

        public SqlCommandBus(Func<SqlConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _messageAdded = new LazyPublisher<SqlCommandMessage>(()=>
                {
                    var isDisposed = false;
                    TplHelper.DoWhile(()=> PollDb().Delay(PollDbInterval), ()=> !isDisposed);
                    TplHelper.DoWhile(() => DbGc().Delay(DbGcInterval), () => !isDisposed);
                    return Disposable.Create(() => isDisposed = true);
                });
        }

        private Task DbGc()
        {
            const string disposeGcSubjects = "delete SheepJaxMessages where PollId=@pollId and Timestamp < @timestamp";
            const string disposeOld = "delete SheepJaxMessages where CreatedUtcTime < select dateadd(minute, -10, GetUtcDate())";

            var con = _connectionFactory();
            return con.WithinTransaction(tx =>
            {
                var cmds = _gcSubjects.ToArray().Select(x=>
                                                 {
                                                     _gcSubjects.Remove(x.Key);
                                                     return new SqlCommand(disposeGcSubjects, con, tx)
                                                                {
                                                                    Parameters =
                                                                        {
                                                                            new SqlParameter("pollId", x.Key),
                                                                            new SqlParameter("timestamp", x.Value)
                                                                        }
                                                                };
                                                 }).ToList();
                cmds.Add(new SqlCommand(disposeOld, con, tx));

                return Task.Factory.ContinueWhenAll(
                    cmds.Select(cmd=> cmd.ExecuteNonQueryAsync()).ToArray(),
                    tasks => tx.Commit());
            });
        }

        private Task PollDb()
        {
            const string sql = "select MessageId, ClientId, Message, Timestamp from SheepJaxMessages";

            return _connectionFactory().WithinTransaction(tx =>
            {
                var cmd = new SqlCommand(sql, tx.Connection, tx);
                if (_lastTimestamp != null)
                {
                    cmd.CommandText += " where timestamp > @lastTimestamp";
                    cmd.Parameters.Add(new SqlParameter("lastTimestamp", _lastTimestamp));
                }
                return cmd.ExecuteReaderAsync().Catch()
                    .Select(reader =>
                    {
                        _cacheLock.EnterWriteLock();
                        try
                        {
                            while (reader.NextResult())
                            {
                                var timestamp = _lastTimestamp = new byte[8];
                                reader.GetBytes(3, 0, timestamp, 0, 8);
                                _cache.AddLast(new SqlCommandMessage
                                        {
                                            MessageId = reader.GetGuid(0),
                                            ClientId = reader.GetGuid(1),
                                            Message = reader.GetString(2),
                                            Timestamp = timestamp
                                        });
                            }
                        }
                        finally
                        {
                            _cacheLock.EnterWriteLock();
                            reader.Close();
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

        public IObservable<CommandMessage> GetObservable(Guid clientId, Guid? previousMessageId)
        {
            LinkedListNode<SqlCommandMessage> previousNode = null;
            if (previousMessageId.HasValue)
            {
                var lastNode = _cache.Last;
                previousNode = FindNext(_cache.First, x => x.MessageId == previousMessageId) ?? lastNode;
                ScheduleForGc(clientId, previousNode);
            }

            return GetObservable(previousNode)
                .Where(x=> x.ClientId == clientId);
        }

        private IObservable<SqlCommandMessage> GetObservable(LinkedListNode<SqlCommandMessage> previousNode)
        {
            return Observable.Create<SqlCommandMessage>(obs =>
                {
                    while (true)
                    {
                        var lastNode = previousNode;
                        for (var next = (previousNode == null) ? _cache.First: previousNode.Next; next != null; next = next.Next)
                        {
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

        private void ScheduleForGc(Guid pollId, LinkedListNode<SqlCommandMessage> node)
        {
            if (node == null)
                return;

            _gcSubjects[pollId] = node.Value;
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