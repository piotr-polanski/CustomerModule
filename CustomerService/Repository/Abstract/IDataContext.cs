using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CustomerService.Repository
{
	interface IDataContext
	{
		DbEntityEntry<T> Entry<T>(T entity) where T : class;

		int SaveChanges();

		IDbSet<T> Set<T>() where T : class;

	}
}
