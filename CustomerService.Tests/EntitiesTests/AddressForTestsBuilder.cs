using CustomerService.Entities;
using Ploeh.AutoFixture;

namespace CustomerService.Tests.EntitiesTests
{
	class AddressForTestsBuilder
	{
		private string _streetName;
		private string _city;
		private string _zipCode;
		private string _country;
		private string _surName;

		public AddressForTestsBuilder()
		{
			var fixture = new Fixture();
			_streetName = fixture.Create<string>();
			_city = fixture.Create<string>();
			_zipCode = fixture.Create<string>();
			_country = fixture.Create<string>();
			_surName = fixture.Create<string>();
		}

		public Address Build()
		{
			return new Address(_streetName, _city, _zipCode, _country);
		}

		public Address BuildInvalid()
		{
			return new Address(null,null,null,null);
		}

		public AddressForTestsBuilder WithoutStreetName()
		{
			_streetName = null;
			return this;
		}

		public AddressForTestsBuilder WithoutCity()
		{
			_city = null;
			return this;
		}

		public AddressForTestsBuilder WithoutZipCode()
		{
			_zipCode = null;
			return this;
		}

		public AddressForTestsBuilder WithoutCountry()
		{
			_country = null;
			return this;
		}
	}
}