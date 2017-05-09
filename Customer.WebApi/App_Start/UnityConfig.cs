using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using CustomerService;

namespace Customer.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
			
			CustomerService.IocConfig.UnityConfig.RegisterComponents(container);
            
			container.RegisterType<ICustomerService, CustomerService.CustomerService>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}