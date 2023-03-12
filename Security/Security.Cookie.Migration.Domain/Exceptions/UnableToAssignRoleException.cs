using System.Runtime.Serialization;

namespace Security.Cookie.Migration.Domain.Exceptions
{
    public class UnableToAssignRoleException : Exception
    {
        public UnableToAssignRoleException()
        {
        }

        public UnableToAssignRoleException(string message) : base(message)
        {
        }

        public UnableToAssignRoleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnableToAssignRoleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
