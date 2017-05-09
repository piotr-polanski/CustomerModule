using CustomerService.Repository;
using CustomerService.Repository.Abstract;
using Microsoft.Practices.Unity;

namespace CustomerService.IocConfig
{
	public class UnityConfig
	{
		public static void RegisterComponents(UnityContainer container)
		{
	        container.RegisterType<IDataContext, CustomerModuleContext>(new PerThreadLifetimeManager());
	        container.RegisterType<IUnitOfWork, EfUnitOfWork>();
	        container.RegisterType<ICustomerRepository, CustomerRepository>();
		}
	}
}
