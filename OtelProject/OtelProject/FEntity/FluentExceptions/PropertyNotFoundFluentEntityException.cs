using System;

namespace FEntity.Exceptions
{
    public class PropertyNotFoundFluentEntityException : FluentException
    {
        public PropertyNotFoundFluentEntityException() : base("Property Not Found")
        {
        }

        public PropertyNotFoundFluentEntityException(string message) : base(message)
        {
        }

        public PropertyNotFoundFluentEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
