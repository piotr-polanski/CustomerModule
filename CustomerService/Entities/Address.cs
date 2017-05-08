using System.IO;
using SimpleValidator.Extensions;

namespace CustomerService.Entities
{
	public class Address
	{
		private Address(){}

		public Address(string streetName, string city, string zipCode, string country)
		{
			if(streetName.IsNullOrEmpty()) throw new InvalidDataException("StreetName should not be null or empty");
			if(city.IsNullOrEmpty()) throw new InvalidDataException("city should not be null or empty");
			if(zipCode.IsNullOrEmpty()) throw new InvalidDataException("zipCode should not be null or empty");
			if(country.IsNullOrEmpty()) throw new InvalidDataException("country should not be null or empty");

			StreetName = streetName;
			City = city;
			ZipCode = zipCode;
			Country = country;
		}

		public string StreetName { get; private set; }
		public string City { get; private set; }
		public string ZipCode { get; private set; }
		public string Country { get; private set; }
	}
}