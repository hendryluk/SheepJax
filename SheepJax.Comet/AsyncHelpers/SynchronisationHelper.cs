using System;
using System.Reactive.Disposables;
using System.Threading;

namespace SheepJax.Comet.AsyncHelpers
{
    public static class SynchronisationHelper
    {
         public static IDisposable BeginReadLock(this ReaderWriterLockSlim lck)
         {
             lck.EnterReadLock();
             return Disposable.Create(lck.ExitReadLock);
         }

         public static IDisposable BeginUpgradeableReadLock(this ReaderWriterLockSlim lck)
         {
             lck.EnterUpgradeableReadLock();
             return Disposable.Create(lck.ExitUpgradeableReadLock);
         }

         public static IDisposable BeginWriteLock(this ReaderWriterLockSlim lck)
         {
             lck.EnterWriteLock();
             return Disposable.Create(lck.ExitWriteLock);
         }
    }
}