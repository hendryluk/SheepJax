// Type: Microsoft.Reactive.Testing.Recorded`1
// Assembly: Microsoft.Reactive.Testing, Version=1.0.10621.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Dev\Codeplex\SheepJax\packages\Rx-Testing.1.0.10621\lib\Net4-Full\Microsoft.Reactive.Testing.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Reactive.Testing
{
  [DebuggerDisplay("{Value}@{Time}")]
  [Serializable]
  public struct Recorded<T> : IEquatable<Recorded<T>>
  {
    private long time;
    private T value;

    public long Time
    {
      get
      {
        return this.time;
      }
    }

    public T Value
    {
      get
      {
        return this.value;
      }
    }

    public Recorded(long time, T value)
    {
      this.time = time;
      this.value = value;
    }

    public static bool operator ==(Recorded<T> left, Recorded<T> right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Recorded<T> left, Recorded<T> right)
    {
      return !left.Equals(right);
    }

    public bool Equals(Recorded<T> other)
    {
      if (this.Time == other.Time)
        return EqualityComparer<T>.Default.Equals(this.Value, other.Value);
      else
        return false;
    }

    public override bool Equals(object obj)
    {
      if (obj is Recorded<T>)
        return this.Equals((Recorded<T>) obj);
      else
        return false;
    }

    public override int GetHashCode()
    {
      return this.Time.GetHashCode() + EqualityComparer<T>.Default.GetHashCode(this.Value);
    }

    public override string ToString()
    {
      return this.Value.ToString() + "@" + this.Time.ToString((IFormatProvider) CultureInfo.CurrentCulture);
    }
  }
}
