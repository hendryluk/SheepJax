using System;

namespace SheepJax.Comet
{
    public interface ICommandBus
    {
        IDisposable Subscribe(Guid pollId, Action<string> onNext);
        IObserver<string> GetObserver(Guid pollId);
    }
}