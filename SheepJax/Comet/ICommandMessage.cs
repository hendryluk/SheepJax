using System;

namespace SheepJax.Comet
{
    public class CommandMessage
    {
        public Guid ClientId { get; set; }
        public Guid MessageId { get; set; }
        public string Message { get; set; }
    }
}