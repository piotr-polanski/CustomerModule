using CustomerService.Entities;
using CustomerService.Repository;

namespace CustomerService
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public void Create(Customer customer)
		{
			customerRepository.Add(customer);
		}

		public void Delete(int id)
		{
			customerRepository.Delete(id);
		}

		public void Update(Customer customer)
		{
			customerRepository.Update(customer);
		}
	}
}