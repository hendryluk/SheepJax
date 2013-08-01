using System;
using System.Threading.Tasks;

namespace SheepJax.Comet.Buses
{
    public interface ICommandBus
    {
        IObservable<CommandMessage> GetObservable(Guid clientId);
        IObserver<string> GetObserver(Guid clientId);
        Task Consumed(CommandMessage last);
    }
}