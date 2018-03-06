using System;
using System.Runtime.Serialization;

namespace CommandLine
{
    [Serializable]
    public class CommandLineParserException : Exception
    {
        public CommandLineParserException()
        {
        }

        public CommandLineParserException(string message) : base(message)
        {
        }

        public CommandLineParserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommandLineParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}