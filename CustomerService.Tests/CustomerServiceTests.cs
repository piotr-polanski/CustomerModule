using System.Linq;
using CustomerService.Entities;
using CustomerService.Repository.Abstract;
using FakeItEasy;
using Ploeh.AutoFixture;
using Xunit;

namespace CustomerService.Tests
{
	public class CustomerServiceTests
	{
		Fixture fixture;
		private ICustomerRepository customerRepository;
		private IUnitOfWork unitOfWork;
		private CustomerService customerService;

		public CustomerServiceTests()
		{
			fixture = new Fixture();
			customerRepository = A.Fake<ICustomerRepository>();
			unitOfWork = A.Fake<IUnitOfWork>();
			customerService = new CustomerService(unitOfWork,customerRepository);
		}

		[Fact]
		public void Create_GivenCustomer_CustomerIsAddedAndSaved()
		{
			//arrange
			var customer = fixture.Create<Customer>();

			//act
			customerService.Create(customer);

			//assert
			A.CallTo(() => customerRepository.Add(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Delete_GivenId_CustomerWithIdIdDeletedAndChangesAreSaved()
		{
			//arrange
			var customerIdToDelete = fixture.Create<int>();

			//act
			customerService.Delete(customerIdToDelete);

			//assert
			A.CallTo(() => customerRepository.Delete(customerIdToDelete))
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Update_GivenCustomer_CustomerIsUpdatedAndSaved()
		{
			//arrange
			var customer = fixture.Create<Customer>();

			//act
			customerService.Update(customer);

			//assert
			A.CallTo(() => customerRepository.Update(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void GetById_IfCustomerExist_Return_Customer()
		{
			//arrange
			var customerId = fixture.Create<int>();

			//act
			customerService.GetById(customerId);

			//assert
			A.CallTo(() => customerRepository.GetById(customerId))
				.MustHaveHappened(Repeated.Exactly.Once);
			
		}

		[Fact]
		public void GetAll_IfCustomerExist_Return_Customer()
		{
			//arrange
			var customers = fixture.Create <EnumerableQuery<Customer>>();
			A.CallTo(() => customerRepository.GetAll())
				.Returns(customers);

			//act
			var customersFromService = customerService.GetAll();


			//assert
			A.CallTo(() => customerRepository.GetAll())
				.MustHaveHappened(Repeated.Exactly.Once);
			Assert.Equal(customers, customersFromService);
			
		}
	}
}