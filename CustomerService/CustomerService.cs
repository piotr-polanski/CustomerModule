using System.Collections.Generic;
using System.Linq;
using CustomerService.Entities;
using CustomerService.Repository;

namespace CustomerService
{
	public class CustomerService : ICustomerService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IRepository<Customer> _customerRepository;

		public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
		{
			_unitOfWork = unitOfWork;
			_customerRepository = customerRepository;
		}

		public void Create(Customer customer)
		{
			customer.Validate();
			_customerRepository.Add(customer);
			_unitOfWork.SaveChanges();
		}

		public void Delete(int id)
		{
			_customerRepository.Delete(id);
			_unitOfWork.SaveChanges();
		}

		public void Update(int id, Customer customer)
		{
			customer.SetId(id);
			Update(customer);
		}

		public void Update(Customer customer)
		{
			customer.Validate();
			_customerRepository.Update(customer);
			_unitOfWork.SaveChanges();
		}

		public IEnumerable<Customer> GetAll()
		{
			return _customerRepository.GetAll().ToList();
		}

		public Customer GetById(int id)
		{
			return _customerRepository.GetById(id);
		}
	}
}