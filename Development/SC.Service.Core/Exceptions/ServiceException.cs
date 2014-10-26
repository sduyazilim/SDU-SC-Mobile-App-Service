using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SC.Service.Core.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ServiceException(HttpStatusCode httpStatusCode, string message)
            : this(httpStatusCode, message, null)
        {
        }

        public ServiceException(HttpStatusCode httpStatusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
