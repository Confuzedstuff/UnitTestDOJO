using System;

namespace Domain.Exceptions.Rocket
{
    public class RocketException : Exception
    {
        public readonly bool IsFatal;

        public RocketException(string message, bool isFatal = true) : base(message)
        {
            this.IsFatal = isFatal;
        }
    }
}