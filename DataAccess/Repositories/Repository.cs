using System.Data.Entity;



namespace DataAccess.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		public Repository(DbContext objectContext)
		{
			_objectContext = objectContext;
		}

		public DbSet<TEntity> All => _objectContext.Set<TEntity>();

		#region Implementation of IRepository<TEntity>

		public void Add(TEntity entity)
		{
			_objectContext.Set<TEntity>().Add(entity);

			_objectContext.SaveChanges();
		}

		public void AddRange(TEntity[] entities)
		{
			_objectContext.Set<TEntity>().AddRange(entities);

			_objectContext.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			_objectContext.Entry<TEntity>(entity).State = EntityState.Modified;

			_objectContext.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			_objectContext.Set<TEntity>().Remove(entity);

			_objectContext.SaveChanges();
		}

		#endregion

		private readonly DbContext _objectContext;
	}
}
