using System.IO;
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
		public string Name { get; }
		public string Surname { get; }
		public string TelephoneNumber { get;}
		public Address Address { get; private set; }

		public void SetId(int id)
		{
			Id = id;
		}
		public void Validate()
		{
			if(Name.IsNullOrEmpty()) throw new InvalidDataException("Name should not be emtpy or null");
			if(Surname.IsNullOrEmpty()) throw new InvalidDataException("Surname should not be emtpy or null");
			if(TelephoneNumber.IsNullOrEmpty()) throw new InvalidDataException("TelephoneNumber should not be emtpy or null");
			if(Address.IsNull()) throw new InvalidDataException("Address should not be null");
		}

	}
}