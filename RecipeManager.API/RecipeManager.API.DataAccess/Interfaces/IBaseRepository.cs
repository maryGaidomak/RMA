namespace RecipeManager.API.DataAccess.Interfaces;

public interface IBaseRepository
{
	Task CreateAsync<T>(T newEntity);
	Task UpdateAsync<T>(T entity);
	Task DeleteAsync<T>(T entity);
	Task<T> GetByIdAsync<T>(Guid id) where T : class;
}
