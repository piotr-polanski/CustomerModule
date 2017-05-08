using CustomerService.Entities;
using CustomerService.Repository;
using FakeItEasy;
using Ploeh.AutoFixture;
using Xunit;

namespace CustomerService.Tests
{
	public class CustomerServiceTests
	{
		private Fixture fixture;

		public CustomerServiceTests()
		{
			fixture = new Fixture();
		}

		[Fact]
		public void Create_GivenCustomer_CustomerIsCreated()
		{
			//arrange
			var customerRepository = A.Fake<ICustomerRepository>();
			var customerService = new CustomerService(customerRepository);
			var customer = fixture.Create<Customer>();

			//act
			customerService.Create(customer);

			//assert
			A.CallTo(() => customerRepository.Add(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Delete_GivenId_CustomerWithIdIdDeleted()
		{
			//arrange
			var customerRepository = A.Fake<ICustomerRepository>();
			var customerService = new CustomerService(customerRepository);
			var customerIdToDelete = fixture.Create<int>();

			//act
			customerService.Delete(customerIdToDelete);

			//assert
			A.CallTo(() => customerRepository.Delete(customerIdToDelete))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Update_GivenCustomer_CustomerIsUpdated()
		{
			//arrange
			var customerRepository = A.Fake<ICustomerRepository>();
			var customerService = new CustomerService(customerRepository);
			var customer = fixture.Create<Customer>();

			//act
			customerService.Update(customer);

			//assert
			A.CallTo(() => customerRepository.Update(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}