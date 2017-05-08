using System.Data.Entity;
using CustomerService.Entities;

namespace CustomerService.Repository
{
	public class CustomerModuleContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
	}
}
