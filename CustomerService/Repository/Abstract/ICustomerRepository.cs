using System.Linq;
using CustomerService.Entities;

namespace CustomerService.Repository
{
	public interface ICustomerRepository : IRepository<Customer> 
	{
		Customer GetById(int id);
	}
}