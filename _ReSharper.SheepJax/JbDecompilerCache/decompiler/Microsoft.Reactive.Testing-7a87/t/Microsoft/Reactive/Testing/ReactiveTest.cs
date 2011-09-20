// Type: Microsoft.Reactive.Testing.ReactiveTest
// Assembly: Microsoft.Reactive.Testing, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Testing.1.0.10621\lib\Net4-Full\Microsoft.Reactive.Testing.dll

using System;
using System.Reactive;

namespace Microsoft.Reactive.Testing
{
  public class ReactiveTest
  {
    public const long Created = 100L;
    public const long Subscribed = 200L;
    public const long Disposed = 1000L;

    public static Recorded<Notification<T>> OnNext<T>(long ticks, T value)
    {
      return new Recorded<Notification<T>>(ticks, Notification.CreateOnNext<T>(value));
    }

    public static Recorded<Notification<T>> OnCompleted<T>(long ticks)
    {
      return new Recorded<Notification<T>>(ticks, Notification.CreateOnCompleted<T>());
    }

    public static Recorded<Notification<T>> OnError<T>(long ticks, Exception exception)
    {
      if (exception == null)
        throw new ArgumentNullException("exception");
      else
        return new Recorded<Notification<T>>(ticks, Notification.CreateOnError<T>(exception));
    }

    public static Subscription Subscribe(long start, long end)
    {
      return new Subscription(start, end);
    }

    public static Subscription Subscribe(long start)
    {
      return new Subscription(start);
    }
  }
}
