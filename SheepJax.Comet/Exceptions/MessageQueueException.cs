using System;

namespace SheepJax.Exceptions
{
    public class MessageQueueException: Exception
    {
        public MessageQueueException(string message): base(message)
        {
            
        }
    }
}