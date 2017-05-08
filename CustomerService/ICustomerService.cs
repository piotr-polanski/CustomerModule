using System.Collections;
using System.Collections.Generic;
using CustomerService.Entities;
namespace CustomerService
{
	public interface ICustomerService
	{
		void Create(Customer customer);
		void Delete(int id);
		void Update(Customer customer);
		IEnumerable<Customer> GetAll();
		Customer GetById(int id);
	}
}