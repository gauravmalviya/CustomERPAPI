using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomERPApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute enableCorsAttribute = new EnableCorsAttribute("*", "*", "*");
            CorsHttpConfigurationExtensions.EnableCors(config, (ICorsPolicyProvider)enableCorsAttribute);
            HttpConfigurationExtensions.MapHttpAttributeRoutes(config);
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", (object)new
            {
                id = RouteParameter.Optional
            });
        }
    }
}
