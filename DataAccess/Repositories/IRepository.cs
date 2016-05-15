using System.Linq;



namespace DataAccess.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> All();

		void Add(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);
	}
}
