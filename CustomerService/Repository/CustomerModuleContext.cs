using System.Data.Entity;
using CustomerService.Entities;
using CustomerService.Repository.Abstract;

namespace CustomerService.Repository
{
	class CustomerModuleContext : DbContext, IDataContext
	{
		public CustomerModuleContext() : base("CustomerModuleContext")
		{
		}

		public new IDbSet<T> Set<T>() where T : class
		{
			return base.Set<T>();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>();
		}
	}

}
