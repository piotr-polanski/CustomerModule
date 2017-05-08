using System.IO;
using SimpleValidator.Extensions;

namespace CustomerService.Entities
{
	public class Customer
	{
		private Customer(){}
		public Customer(string name, string surname, string telephoneNumber, Address address)
		{
			if(name.IsNullOrEmpty()) throw new InvalidDataException("Name should not be emtpy or null");
			if(surname.IsNullOrEmpty()) throw new InvalidDataException("Surname should not be emtpy or null");
			if(telephoneNumber.IsNullOrEmpty()) throw new InvalidDataException("TelephoneNumber should not be emtpy or null");
			if(address.IsNull()) throw new InvalidDataException("Address should not be null");

			Name = name;
			Surname = surname;
			TelephoneNumber = telephoneNumber;
			Address = address;
		}
		public string Name { get; private set; }
		public string Surname { get; private set; }
		public string TelephoneNumber { get; private set; }
		public Address Address { get; private set; }

	}
}