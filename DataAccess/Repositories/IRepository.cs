using System.Data.Entity;



namespace DataAccess.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		DbSet<TEntity> All { get; }

		void Add(TEntity entity);

		void AddRange(TEntity[] entities);

		void Update(TEntity entity);

		void Delete(TEntity entity);
	}
}
