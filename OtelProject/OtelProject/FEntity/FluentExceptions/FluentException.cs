using System;

namespace FEntity.Exceptions
{
    public class FluentException : Exception
    {
        public FluentException() : base()
        {
        }

        public FluentException(string message) : base(message)
        {
        }

        public FluentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
