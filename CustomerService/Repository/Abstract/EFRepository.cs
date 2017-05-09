using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CustomerService.Exceptions;

namespace CustomerService.Repository.Abstract
{
	abstract class EfRepository<T> where T : class 
	{
		protected readonly IDataContext Context;

		public EfRepository(IDataContext context)
		{
			Context = context;
		}

		public virtual IQueryable<T> GetAll()
		{
			return Context.Set<T>();
		}

		public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
		{
			return Context.Set<T>().Where(predicate);
		}

		public virtual void Add(T entity)
		{
			Context.Set<T>().Add(entity);
		}

		public virtual void Delete(int id)
		{
			var entity = Context.Set<T>().Find(id);
			if (entity != null)
			{
				Context.Set<T>().Remove(entity);
			}
			else
			{
				throw new EntityNotFoundException();
			}
		}

		public virtual void Update(T entity)
		{
			Context.Set<T>().Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
		}

	}
}
