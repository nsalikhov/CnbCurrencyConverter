using System.Data.Entity;
using System.Linq;



namespace DataAccess.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		public Repository(DbContext objectContext)
		{
			_objectContext = objectContext;
		}

		#region Implementation of IRepository<TEntity>

		public virtual void Add(TEntity entity)
		{
			_objectContext.Set<TEntity>().Add(entity);

			_objectContext.SaveChanges();
		}

		public void AddRange(TEntity[] entities)
		{
			_objectContext.Set<TEntity>().AddRange(entities);

			_objectContext.SaveChanges();
		}

		public virtual void Update(TEntity entity)
		{
			_objectContext.Entry<TEntity>(entity).State = EntityState.Modified;

			_objectContext.SaveChanges();
		}

		public virtual void Delete(TEntity entity)
		{
			_objectContext.Set<TEntity>().Remove(entity);

			_objectContext.SaveChanges();
		}

		public virtual IQueryable<TEntity> All()
		{
			return _objectContext.Set<TEntity>();
		}

		#endregion

		private readonly DbContext _objectContext;
	}
}
