using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CustomerService.Exceptions;

namespace CustomerService.Repository
{
	abstract class EFRepository<T> where T : class 
	{
		protected readonly IDataContext context;

		public EFRepository(IDataContext context)
		{
			this.context = context;
		}

		public virtual IQueryable<T> GetAll()
		{
			return context.Set<T>();
		}

		public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
		{
			return context.Set<T>().Where(predicate);
		}

		public virtual void Add(T entity)
		{
			context.Set<T>().Add(entity);
		}

		public virtual void Delete(int id)
		{
			var entity = context.Set<T>().Find(id);
			if (entity != null)
			{
				context.Set<T>().Remove(entity);
			}
			else
			{
				throw new EntityNotFoundException();
			}
		}

		public virtual void Update(T entity)
		{
			context.Set<T>().Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

	}
}
