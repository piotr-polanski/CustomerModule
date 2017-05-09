using CustomerService.Exceptions;
using SimpleValidator.Extensions;

namespace CustomerService.Entities
{
	public class Customer
	{
		private Customer(){}
		public Customer(string name, string surname, string telephoneNumber, Address address)
		{
			Name = name;
			Surname = surname;
			TelephoneNumber = telephoneNumber;
			Address = address;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Surname { get; private set; }
		public string TelephoneNumber { get; private set; }
		public Address Address { get; private set; }

		public void SetId(int id)
		{
			Id = id;
		}
		public void Validate()
		{
			if(Name.IsNullOrEmpty()) throw new CustomerInvalidException("Name should not be emtpy or null");
			if(Surname.IsNullOrEmpty()) throw new CustomerInvalidException("Surname should not be emtpy or null");
			if(TelephoneNumber.IsNullOrEmpty()) throw new CustomerInvalidException("TelephoneNumber should not be emtpy or null");
			if(Address.IsNull()) throw new CustomerInvalidException("Address should not be null");
			Address.Validate();
		}

	}
}