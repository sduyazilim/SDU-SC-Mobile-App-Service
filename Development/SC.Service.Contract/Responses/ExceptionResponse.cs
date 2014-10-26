using System.Net;

namespace SC.Service.Contract.Responses
{
    public class ExceptionResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string FriendlyDescription { get; set; }
        public string DetailedDescription { get; set; }
    }
}
