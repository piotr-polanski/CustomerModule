using CustomerService.Entities;

namespace CustomerService.Repository
{
	public interface ICustomerRepository
	{
		void Add(Customer customer);
		void Delete(int id);
		void Update(Customer customer);
	}
}