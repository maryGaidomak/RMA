using MongoDB.Driver;

namespace RecipeManager.API.DataAccess.Contracts
{
	public interface IMongoRepository<T>
	{
		Task<IEnumerable<T>> GetAllAsync(ProjectionDefinition<T> project, int limit);
		Task<IEnumerable<T>> GetAllAsync(FilterDefinition<T> filter, ProjectionDefinition<T> projection, int limit);
		Task<T> GetByIdAsync(Guid id);
		Task<T> CreateAsync(T entity);
		Task UpdateAsync(Guid id, T entity);
		Task DeleteAsync(Guid id);

	}
}
