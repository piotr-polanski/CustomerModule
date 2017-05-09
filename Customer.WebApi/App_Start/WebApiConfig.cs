using System.Web.Http;
using Customer.WebApi.Filters;

namespace Customer.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services

			config.Filters.Add(new CustomerServiceExceptionAttribute());

			log4net.Config.XmlConfigurator.Configure();
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
