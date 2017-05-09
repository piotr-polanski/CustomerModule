using CustomerService.Entities;
using Ploeh.AutoFixture;

namespace CustomerService.Tests
{
	class CustomerBuilder
	{
		private string _name;
		private string _streetName;
		private string _city;
		private string _zipCode;
		private string _country;
		private string _surName;
		private string _telephoneNumber;
		private bool _withAddress;

		public CustomerBuilder()
		{
			var fixture = new Fixture();
			_name = fixture.Create<string>();
			_streetName = fixture.Create<string>();
			_city = fixture.Create<string>();
			_zipCode = fixture.Create<string>();
			_country = fixture.Create<string>();
			_surName = fixture.Create<string>();
			_telephoneNumber = fixture.Create<string>();
		}

		public CustomerBuilder WithoutName()
		{
			_name = null;
			return this;
		}

		public CustomerBuilder WithoutSurname()
		{
			_surName = null;
			return this;
		}

		public CustomerBuilder WithoutTelephoneNumber()
		{
			_telephoneNumber = null;
			return this;
		}

		public CustomerBuilder WithoutAddress()
		{
			_withAddress = false;
			return this;
		}
		public Customer Build()
		{
			Address address = null;
			if (_withAddress)
			{
				address = new Address(_streetName, _city, _zipCode, _country);
			}
			return new Customer(_name, _surName, _telephoneNumber, address);
		}
	}
}