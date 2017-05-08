using System.Data.Entity;
using CustomerService.Entities;

namespace CustomerService.Repository
{
	public class CustomerModuleContext : DbContext, IDataContext
	{
		public CustomerModuleContext() : base("CustomerModuleContext")
		{
		}

		public IDbSet<T> Set<T>() where T : class
		{
			return base.Set<T>();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>();
		}
	}

}
