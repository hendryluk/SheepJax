using System;
using System.Reactive.Disposables;
using System.Threading;

namespace SheepJax.AsyncHelpers
{
    public static class SynchronisationHelper
    {
         public static IDisposable BeginReadLock(this ReaderWriterLockSlim lck)
         {
             if (!lck.TryEnterReadLock(2000))
                 throw new Exception("Blah!!");


             //lck.EnterReadLock();
             return Disposable.Create(lck.ExitReadLock);
         }

         public static IDisposable BeginUpgradeableReadLock(this ReaderWriterLockSlim lck)
         {
             if (!lck.TryEnterUpgradeableReadLock(2000))
                 throw new Exception("Blah!!");

             //lck.EnterUpgradeableReadLock();
             return Disposable.Create(lck.ExitUpgradeableReadLock);
         }

         public static IDisposable BeginWriteLock(this ReaderWriterLockSlim lck)
         {
             if (!lck.TryEnterWriteLock(2000))
                 throw new Exception("Blah!!");

             //lck.EnterWriteLock();
             return Disposable.Create(lck.ExitWriteLock);
         }
    }
}