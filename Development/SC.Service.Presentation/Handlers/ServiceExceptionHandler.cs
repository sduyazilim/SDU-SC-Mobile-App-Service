using SC.Service.Contract.Responses;
using SC.Service.Core.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SC.Service.Presentation.Handlers
{
    public class ServiceExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ExceptionResult(context.Exception, context.Request);
        }
    }

    public class ExceptionResult : IHttpActionResult
    {
        private HttpRequestMessage httpRequestMessage;
        private Exception exception;

        public ExceptionResult(Exception exception, HttpRequestMessage httpRequestMessage)
        {
            this.exception = exception;
            this.httpRequestMessage = httpRequestMessage;
        }

        public Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            ExceptionResponse response = new ExceptionResponse
            {
                DetailedDescription = GetDetailedExceptionMessage(),
                HttpStatusCode = HttpStatusCode.InternalServerError //Default HttpStatusCode
            };

            if (exception is ServiceException)
            {
                response.HttpStatusCode = ((ServiceException)exception).HttpStatusCode;
                response.FriendlyDescription = ((ServiceException)exception).Message;
            }

            return Task.FromResult(httpRequestMessage.CreateResponse<ExceptionResponse>(response.HttpStatusCode, response));
        }

        private string GetDetailedExceptionMessage()
        {
            StringBuilder builder = new StringBuilder();
            Exception inner = exception;

            while (inner != null)
            {
                builder.AppendLine(inner.Message);
                builder.AppendLine(inner.StackTrace);
                builder.AppendLine("-------------------");
                inner = exception.InnerException;
            }

            return builder.ToString();
        }
    }

    
}