using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;
using DAccess = RecipeManager.API.DataAccess.DataClasses;
using RecipeManager.API.DataAccess.Contracts;

namespace RecipeManager.API.BL;

public class IngredientService : IIngredientService
{
	private readonly IMongoRepository<DAccess.Ingredient> _repository;
	public IngredientService(IMongoRepository<DAccess.Ingredient> repository)
	{
		_repository = repository;
	}

	public async Task CreateAsync(Ingredient ingredient)
	{
		await _repository.CreateAsync(new DAccess.Ingredient()
		{
			FullName = ingredient.FullName,
			ShortName = ingredient.ShortName,
			Description = ingredient.Description,
		});
	}

	public bool Delete(Guid id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Ingredient>> GetAll()
	{
		var dbResults = await _repository.GetAllAsync(null, 10);
		var results = dbResults.Select(i => new Ingredient()
		{
			Id = i.Id,
			FullName = i.FullName,
			ShortName = i.ShortName,
			Description = i.Description
		}).ToList();
		return results;
	}

	public Ingredient GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	public Ingredient? Search(string name)
	{
		throw new NotImplementedException();
	}

	public bool Update(Ingredient ingredient)
	{
		throw new NotImplementedException();
	}
}
