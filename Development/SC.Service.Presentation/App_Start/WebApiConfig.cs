using SC.Service.Presentation.Handlers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SC.Service.Presentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            config.Services.Replace(typeof(IExceptionHandler), new ServiceExceptionHandler());
        }
    }
}
