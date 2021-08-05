using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
