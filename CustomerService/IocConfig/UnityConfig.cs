using CustomerService.Entities;
using CustomerService.Repository;
using Microsoft.Practices.Unity;

namespace CustomerService.IocConfig
{
	public class UnityConfig
	{
		public static void RegisterComponents(UnityContainer container)
		{
	        container.RegisterType<IDataContext, CustomerModuleContext>(new PerThreadLifetimeManager());
	        container.RegisterType<IUnitOfWork, EFUnitOfWork>();
	        container.RegisterType<IRepository<Customer>, CustomerRepository>();
		}
	}
}
