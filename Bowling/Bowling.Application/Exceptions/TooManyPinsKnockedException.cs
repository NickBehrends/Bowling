using System;
using System.Runtime.Serialization;

namespace Bowling.Application.Exceptions
{
    [Serializable]
    public class TooManyPinsKnockedException : Exception
    {
        public TooManyPinsKnockedException()
        {
        }

        public TooManyPinsKnockedException(string message)
            : base(message)
        {
        }

        public TooManyPinsKnockedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TooManyPinsKnockedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}