using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PIT.REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureRouting(config);
            ConfigureFormatters(config);
        }

        private static void ConfigureRouting(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("Projects", "api/projects/{id}",
                new {controller = "projects", id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute("Issues", "api/issues/{id}",
                new {controller = "issues", id = RouteParameter.Optional}
                );
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}