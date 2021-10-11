using System;
using System.Runtime.Serialization;

namespace Bowling.Application.Exceptions
{
    [Serializable]
    public class GameAlreadyInProgressException : Exception
    {
        public GameAlreadyInProgressException()
        {
        }

        public GameAlreadyInProgressException(string message)
            : base(message)
        {
        }

        public GameAlreadyInProgressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected GameAlreadyInProgressException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}