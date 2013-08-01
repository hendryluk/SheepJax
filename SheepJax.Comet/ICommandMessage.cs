using System;

namespace SheepJax.Comet
{
    public class CommandMessage
    {
        public Guid ClientId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedUtcTime { get; set; }
    }
}