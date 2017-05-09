using System.Collections.Generic;
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
		public void Create_GivenCustomerIsValid_CustomerIsAddedAndSaved()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().Build();

			//act
			customerService.Create(customer);

			//assert
			A.CallTo(() => customerRepository.Add(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Create_GivenInvalidCustomer_ThereIsNoAddAndSave()
		{
			//arrange
			var invalidCustomer = new CustomerForTestsBuilder().BuildInvalid();

			//act
			Record.Exception(() => customerService.Create(invalidCustomer));

			//assert
			A.CallTo(() => customerRepository.Add(invalidCustomer))
				.MustHaveHappened(Repeated.Never);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Never);
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
		public void Update_GivenValidCustomer_CustomerIsUpdatedAndSaved()
		{
			//arrange
			var customer = new CustomerForTestsBuilder().Build();

			//act
			customerService.Update(customer);

			//assert
			A.CallTo(() => customerRepository.Update(customer))
				.MustHaveHappened(Repeated.Exactly.Once);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Exactly.Once);
		}

		[Fact]
		public void Update_GivenInvalidCustomer_ThereIsNoUpdateAndSave()
		{
			//arrange
			var invalidCustomer = new CustomerForTestsBuilder().BuildInvalid();

			//act
			Record.Exception(() => customerService.Update(invalidCustomer));

			//assert
			A.CallTo(() => customerRepository.Update(invalidCustomer))
				.MustHaveHappened(Repeated.Never);
			A.CallTo(() => unitOfWork.SaveChanges())
				.MustHaveHappened(Repeated.Never);
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
			var customers = new List<Customer>()
			{
				new CustomerForTestsBuilder().Build(),
				new CustomerForTestsBuilder().Build()
			}.AsQueryable();

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