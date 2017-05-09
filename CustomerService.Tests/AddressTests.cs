using CustomerService.Exceptions;
using Xunit;

namespace CustomerService.Tests
{
	public class AddressTests
	{
		[Fact]
		public void Validate_StreetNameIsNull_ThrowsInvalidAddressException()
		{
			//arange
			var address = new AddressForTestsBuilder().WithoutStreetName().Build();

			//act
			var exception = Record.Exception(() => address.Validate());

			//assert
			Assert.IsType<AddressInvalidException>(exception);
		}
		[Fact]
		public void Validate_CityIsNull_ThrowsInvalidAddressException()
		{
			//arange
			var address = new AddressForTestsBuilder().WithoutCity().Build();

			//act
			var exception = Record.Exception(() => address.Validate());

			//assert
			Assert.IsType<AddressInvalidException>(exception);
		}
		[Fact]
		public void Validate_ZipCodeIsNull_ThrowsInvalidAddressException()
		{
			//arange
			var address = new AddressForTestsBuilder().WithoutZipCode().Build();

			//act
			var exception = Record.Exception(() => address.Validate());

			//assert
			Assert.IsType<AddressInvalidException>(exception);
		}
		[Fact]
		public void Validate_CountryIsNull_ThrowsInvalidAddressException()
		{
			//arange
			var address = new AddressForTestsBuilder().WithoutCountry().Build();

			//act
			var exception = Record.Exception(() => address.Validate());

			//assert
			Assert.IsType<AddressInvalidException>(exception);
		}
	}
}
