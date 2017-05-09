namespace CustomerService.Repository
{
	class EFUnitOfWork : IUnitOfWork
	{
		private readonly IDataContext _dataContext;

		public EFUnitOfWork(IDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void SaveChanges()
		{
			_dataContext.SaveChanges();
		}
	}
}
