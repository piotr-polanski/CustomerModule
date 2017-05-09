using System.Data.Entity;
using System.Linq;
using CustomerService.Entities;
using CustomerService.Exceptions;
using CustomerService.Repository.Abstract;

namespace CustomerService.Repository
{
	class CustomerRepository : EfRepository<Customer>, ICustomerRepository
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
