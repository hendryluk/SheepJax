using System;

namespace SheepJax.Comet
{
    public class CometException : Exception
    {
        public CometException(string message): base(message)
        {
        }
    }
}