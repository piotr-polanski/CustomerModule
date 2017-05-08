using System.Data.Entity;
using System.Linq;
using CustomerService.Entities;

namespace CustomerService.Repository
{
	public class CustomerRepository : EFRepository<Customer>, IRepository<Customer>
	{
		public CustomerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Customer> GetAll()
		{
			return base.GetAll().Include(c => c.Address);
		}

		public Customer GetById(int id)
		{
			return GetBy(c => c.Id == id)
				.Include(c => c.Address)
				.FirstOrDefault();
		}

	}
}
