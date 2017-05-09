using CustomerService.Repository.Abstract;

namespace CustomerService.Repository
{
	class EfUnitOfWork : IUnitOfWork
	{
		private readonly IDataContext _dataContext;

		public EfUnitOfWork(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void SaveChanges()
		{
			_dataContext.SaveChanges();
		}
	}
}
