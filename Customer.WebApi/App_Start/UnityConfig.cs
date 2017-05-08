using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using CustomerService;
using CustomerService.Repository;

namespace Customer.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
			container.RegisterType<ICustomerService, CustomerService.CustomerService>();
	        container.RegisterType<IDataContext, CustomerModuleContext>(new PerThreadLifetimeManager());
	        container.RegisterType<IUnitOfWork, EFUnitOfWork>();
	        container.RegisterType<IRepository<CustomerService.Entities.Customer>, CustomerRepository>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}