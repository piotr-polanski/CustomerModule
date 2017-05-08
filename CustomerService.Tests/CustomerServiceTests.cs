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
			var customerRepository = A.Fake<IRepository<Customer>>();
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
			var customerRepository = A.Fake<IRepository<Customer>>();
			var customerService = new CustomerService(customerRepository);
			var customerToDelete = fixture.Create<Customer>();
			var customerIdToDelete = fixture.Create<int>();
			A.CallTo(() => customerRepository.FindById(customerIdToDelete))
				.Returns(customerToDelete);

			//act
			customerService.Delete(customerIdToDelete);

			//assert
			A.CallTo(() => customerRepository.Delete(customerToDelete))
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Update_GivenCustomer_CustomerIsUpdated()
		{
			//arrange
			var customerRepository = A.Fake<IRepository<Customer>>();
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