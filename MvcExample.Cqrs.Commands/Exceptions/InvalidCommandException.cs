using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MvcExample.Cqrs.Commands.Exceptions
{
    public class InvalidCommandException<TCommand> : Exception
    {
        public TCommand CommandDto { get; set; }
        public List<string> ValidationMessages { get; set; }

        public InvalidCommandException(TCommand command, List<string> messages)
        {
            CommandDto = command;
            ValidationMessages = messages;
        }

        public InvalidCommandException() : base() { }

        public InvalidCommandException(string message) : base(message) { }

        public InvalidCommandException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidCommandException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }
    }
}
