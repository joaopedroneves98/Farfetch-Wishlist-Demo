namespace Presentation.WebAPI
{
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;
    using Farfetch.Framework.Rest.Common;
    using Farfetch.Framework.Rest.Server.Handlers;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var exceptionHandler = new GlobalExceptionHandler();

            config.Services.Replace(typeof(IExceptionHandler), exceptionHandler);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
