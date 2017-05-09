using CustomerService.Exceptions;
using SimpleValidator.Extensions;

namespace CustomerService.Entities
{
	public class Address
	{
		private Address(){}

		public Address(string streetName, string city, string zipCode, string country)
		{
			StreetName = streetName;
			City = city;
			ZipCode = zipCode;
			Country = country;
		}

		public int Id { get; private set; }
		public string StreetName { get; private set; }
		public string City { get; private set; }
		public string ZipCode { get; private set; }
		public string Country { get; private set; }

		public void Validate()
		{
			if(StreetName.IsNullOrEmpty()) throw new AddressInvalidException("StreetName should not be null or empty");
			if(City.IsNullOrEmpty()) throw new AddressInvalidException("city should not be null or empty");
			if(ZipCode.IsNullOrEmpty()) throw new AddressInvalidException("zipCode should not be null or empty");
			if(Country.IsNullOrEmpty()) throw new AddressInvalidException("country should not be null or empty");
		}
	}
}