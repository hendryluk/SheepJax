using System;
using Common.Logging;

namespace SheepJax.Comet
{
    public class PollableTask
    {
        public static readonly ILog Logger = LogManager.GetLogger<PollableTask>();

        public Guid Id { get; private set; }
        private readonly Action<IObserver<SheepJaxInvoke>> _startExecution;

        /// <summary>
        /// Create a new PollableTask
        /// </summary>
        /// <param name="startExecution">
        /// Action to be executed when the task is started.
        /// Parameter: onInvoked, onCompleted
        /// </param>
        public PollableTask(Action<IObserver<SheepJaxInvoke>> startExecution)
        {
            Id = Guid.NewGuid();
            _startExecution = startExecution;
        }

        public void Start(IObserver<SheepJaxInvoke> observer)
        {
            _startExecution(observer);
        }
    }
}