using CustomERPApi;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CustomERPApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Assembly assembly = typeof(SwaggerConfig).Assembly;
            Swashbuckle.Application.HttpConfigurationExtensions.EnableSwagger(
                GlobalConfiguration.Configuration, 
                (Action<SwaggerDocsConfig>)(
                c => {
                    c.SingleApiVersion("v1", "CustomERPApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }
                ))
                .EnableSwaggerUi((Action<SwaggerUiConfig>)(c => { }));
        }
    }
}
