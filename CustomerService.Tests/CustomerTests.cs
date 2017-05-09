using CustomerService.Exceptions;
using Xunit;

namespace CustomerService.Tests
{
	public class CustomerTests
	{
		[Fact]
		public void Validate_WhenNameIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().WithoutName().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenSurnameIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().WithoutSurname().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenTelephoneNumberIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().WithoutTelephoneNumber().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenAddressIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().WithoutAddress().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
	}
}
