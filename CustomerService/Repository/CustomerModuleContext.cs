using System.Data.Entity;
using CustomerService.Entities;

namespace CustomerService.Repository
{
	public class CustomerModuleContext : DbContext
	{
		public CustomerModuleContext() : base("CustomerModuleContext")
		{
			
		}
		public DbSet<Customer> Customers { get; set; }
	}
}
