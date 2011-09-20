using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Reactive.Testing;
using NUnit.Framework;
using SheepJax.RxHelpers;
using FluentAssertions;

namespace SheepJax.Tests.Comet
{
    [TestFixture]
    public class ObservableBatcherTest: ReactiveTest
    {
        //[Test]
        //public void ObservableCanCompleteBeforeBatch()
        //{
        //    var schedule = new TestScheduler();
            
        //    var batchSize = TimeSpan.FromTicks(1000);

        //    var obs = schedule.CreateHotObservable(
        //        OnNext(100, "one"),
        //        OnNext(150, "two"),
        //        OnNext(1101, "three")
        //        );

        //    var results = schedule.Start(() => obs.Batch(batchSize, schedule), 0, 0, 1500);
        //    results.Messages.Should().HaveCount(1);
        //    results.Messages[0].Value.Value.Should().BeEquivalentTo((object)"one", "two");
        //    results.Messages[0].Time.Should().Be(150);
        //}

        //[Test]
        //public void ShouldOnlySubscribeOnce()
        //{
        //    var subscribed = 0;
        //    var schedule = new TestScheduler();
            
        //    var obs = schedule.CreateHotObservable(
        //        OnNext(2000, "one"),
        //        OnNext(2150, "two"),
        //        OnNext(3001, "three")
        //        );
            
        //    Func<Action<string>, IDisposable> subscribe = onNext =>
        //                                           {
        //                                               subscribed++;
        //                                               return obs.Subscribe(onNext);
        //                                           };

        //    var sut = Observable.Create<string>(observer => subscribe(observer.OnNext));
        //    var list = new List<string>();
        //    sut.Take(1).Subscribe(x =>
        //                              {
        //                                  list.Add(x);
        //                                  sut.Timeout(TimeSpan.FromTicks(1000)).Subscribe(list.Add, e=> { });
        //                              });

        //    schedule.Start();
        //    subscribed.Should().Be(1);
        //    list.Should().BeEquivalentTo((object)"one", "two");
        //}

        [Test]
        public void SheepSpike()
        {
            var queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");
            queue.Enqueue("four");
            queue.Enqueue("five");
            queue.Enqueue("six");

            var a = Observable.Create<string>(ob =>
                                                  {
                                                      Console.WriteLine("Subscribed!");
                                                      var isDisposed = false;
                                                          
                                                      Task.Factory.StartNew(delegate
                                                      {
                                                          Thread.Sleep(2000);

                                                          while (!isDisposed && queue.Count > 0)
                                                          {
                                                              Thread.Sleep(100);
                                                              var val = queue.Dequeue();
                                                              Console.WriteLine("Returning " + val);
                                                              ob.OnNext(val);
                                                          }
                                                      });
                                                      return () => { 
                                                          isDisposed = true;
                                                                       Console.WriteLine("Disposed!");
                                                      };
                                                  });

            var obs = a.Replay();
            var subscription = obs.Connect();

            var timeout = Observable.Interval(TimeSpan.FromMilliseconds(3000));

            obs.TakeUntil(timeout).TakeUntil(obs.Take(1).Delay(TimeSpan.FromMilliseconds(150))).Subscribe(msg => Console.WriteLine("Received: " + msg),
                                          () =>
                                              {
                                                  Console.WriteLine("COMPLETED!!");
                                              });

            Console.WriteLine("Connected!!");
            
            //obs.Do(msg=> Console.WriteLine("Received: " + msg), 
            //    () =>
            //    {
            //        Console.WriteLine("COMPLETED!!");
            //    }).Take(1).Subscribe(_ => new Timer(t => subscription.Dispose()).Change(TimeSpan.FromMilliseconds(150), TimeSpan.FromMilliseconds(-1)));

            Thread.Sleep(10000);
        }
    }
}