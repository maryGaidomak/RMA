using Microsoft.EntityFrameworkCore;
using RecipeManager.API.DataAccess.Interfaces;

namespace RecipeManager.API.DataAccess;

public class BaseRepository : IBaseRepository
{
	private readonly RecipeBookContext _dbContext;
	public BaseRepository(RecipeBookContext context)
	{
		_dbContext = context;
	}
	public async Task CreateAsync<T>(T newEntity)
	{
		await _dbContext.AddAsync(newEntity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync<T>(T entity)
	{
		_dbContext.Update(entity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync<T>(T entity)
	{
		_dbContext.Remove(entity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<T> GetByIdAsync<T>(Guid id)
		where T : class
	{
		return await _dbContext.FindAsync<T>(id);
	}

}
