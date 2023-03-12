using System.Runtime.Serialization;

namespace Security.Cookie.Migration.Domain.Exceptions
{
    public class UnableToAddRoleException : Exception
    {
        public UnableToAddRoleException()
        {
        }

        public UnableToAddRoleException(string message) : base(message)
        {
        }

        public UnableToAddRoleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnableToAddRoleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
