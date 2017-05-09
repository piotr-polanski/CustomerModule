using CustomerService.Entities;
using Ploeh.AutoFixture;

namespace CustomerService.Tests.EntitiesTests
{
	class CustomerForTestsBuilder
	{
		private string _name;
		private string _surName;
		private string _telephoneNumber;
		private bool _withAddress;
		private AddressForTestsBuilder _addressBuilder;

		public CustomerForTestsBuilder()
		{
			var fixture = new Fixture();
			_addressBuilder = new AddressForTestsBuilder();
			_withAddress = true;
			_name = fixture.Create<string>();
			_surName = fixture.Create<string>();
			_telephoneNumber = fixture.Create<string>();
		}

		public CustomerForTestsBuilder WithoutName()
		{
			_name = null;
			return this;
		}

		public CustomerForTestsBuilder WithoutSurname()
		{
			_surName = null;
			return this;
		}

		public CustomerForTestsBuilder WithoutTelephoneNumber()
		{
			_telephoneNumber = null;
			return this;
		}

		public CustomerForTestsBuilder WithoutAddress()
		{
			_withAddress = false;
			return this;
		}
		public Customer Build()
		{
			Address address = null;
			if (_withAddress)
			{
				address = _addressBuilder.Build();
			}
			return new Customer(_name, _surName, _telephoneNumber, address);
		}

		public Customer BuildInvalid()
		{
			return new Customer(null,null,null,null);
		}
	}
}