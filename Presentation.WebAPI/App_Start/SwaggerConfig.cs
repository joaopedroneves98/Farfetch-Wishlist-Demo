using System.Web.Http;
using WebActivatorEx;
using Presentation.WebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Presentation.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => { c.SingleApiVersion("v1", "Presentation.WebAPI");})
                .EnableSwaggerUi(c => { c.DocumentTitle("Wishlist"); });
        }
    }
}
