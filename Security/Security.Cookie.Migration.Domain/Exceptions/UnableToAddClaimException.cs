using System.Runtime.Serialization;

namespace Security.Cookie.Migration.Domain.Exceptions
{
    public class UnableToAddClaimException : Exception
    {
        public UnableToAddClaimException()
        {
        }

        public UnableToAddClaimException(string message) : base(message)
        {
        }

        public UnableToAddClaimException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnableToAddClaimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
