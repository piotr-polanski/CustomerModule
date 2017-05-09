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
			var customer = new CustomerBuilder().WithoutName().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenSurnameIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerBuilder().WithoutSurname().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenTelephoneNumberIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerBuilder().WithoutTelephoneNumber().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
		[Fact]
		public void Validate_WhenAddressIsNull_ThrowsInvalidCustomerException()
		{
			//arrange
			var customer = new CustomerBuilder().WithoutAddress().Build();

			//act
			var exception = Record.Exception(() => customer.Validate());

			//assert
			Assert.IsType<CustomerInvalidException>(exception);
		}
	}
}
