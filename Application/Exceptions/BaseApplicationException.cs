using System;
using System.Net;

namespace Application.Exceptions
{
    public abstract class BaseApplicationException : ApplicationException
    {
        public abstract HttpStatusCode HttpStatusCode { get; }

        protected BaseApplicationException()
        {
        }

        protected BaseApplicationException(string message) : base(message)
        {

        }
    }
}
