using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerService.Repository
{
	public class EFRepository<T> where T : class 
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
			context.Set<T>().Remove(entity);
		}

		public virtual void Update(T entity)
		{
			context.Set<T>().Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
		}

	}
}
