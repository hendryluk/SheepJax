using System;

namespace SheepJax.Comet.Exceptions
{
    public class MessageQueueException: Exception
    {
        public MessageQueueException(string message): base(message)
        {
            
        }
    }
}