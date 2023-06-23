using System.Runtime.Serialization;

namespace TA.Domain.Exceptions
{
    public class InvalidArgumentException : Exception
    {
        public string ArgumentName { get; set; }

        public InvalidArgumentException(string argumentName)
        {
            ArgumentName = argumentName;
        }

        public InvalidArgumentException(string message, string argumentName) : base(message)
        {
            ArgumentName = argumentName;
        }

        public InvalidArgumentException(string message, Exception innerException, string argumentName) : base(message, innerException)
        {
            ArgumentName = argumentName;
        }

        protected InvalidArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
