using CustomerService.Entities;

namespace CustomerService.Repository.Abstract
{
	public interface ICustomerRepository : IRepository<Customer> 
	{
		new Customer GetById(int id);
	}
}