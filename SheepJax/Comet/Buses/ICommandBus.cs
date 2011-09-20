using System;

namespace SheepJax.Comet.Buses
{
    public interface ICommandBus
    {
        IObservable<CommandMessage> GetObservable(Guid clientId, Guid? previousMessageId);
        IObserver<string> GetObserver(Guid clientId);
    }
}