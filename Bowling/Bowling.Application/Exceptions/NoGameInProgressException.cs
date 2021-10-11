using System;
using System.Runtime.Serialization;

namespace Bowling.Application.Exceptions
{
    [Serializable]
    public class NoGameInProgressException : Exception
    {
        public NoGameInProgressException()
        {
        }

        public NoGameInProgressException(string message)
            : base(message)
        {
        }

        public NoGameInProgressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NoGameInProgressException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}