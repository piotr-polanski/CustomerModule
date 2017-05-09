using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerService.Repository
{
	public interface IRepository<T> 
	{
		IQueryable<T> GetAll();

		IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

		void Add(T entity);

		void Delete(int id);

		void Update(T entity);
		T GetById(int id);
	}
}