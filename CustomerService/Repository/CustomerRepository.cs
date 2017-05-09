using System.Data.Entity;
using System.Linq;
using CustomerService.Entities;
using CustomerService.Exceptions;

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
			var customer = GetBy(c => c.Id == id)
				.Include(c => c.Address)
				.FirstOrDefault();
			if (customer != null)
			{
				return customer;
			}
			throw new EntityNotFoundException();

		}

	}
}
