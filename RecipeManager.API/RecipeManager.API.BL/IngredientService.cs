using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;
using RecipeManager.API.DataAccess.Contracts;

namespace RecipeManager.API.BL;

public class IngredientService : IIngredientService
{
	private readonly IIngredientsRepository _ingredientsRepository;
	public IngredientService(IIngredientsRepository ingredientsRepository)
	{
		_ingredientsRepository = ingredientsRepository;
	}

	public async Task CreateAsync(Ingredient ingredient)
	{
		await _ingredientsRepository.CreateIngredient(new DataAccess.DataClasses.Ingredient()
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
		var dbResults = await _ingredientsRepository.GetAllIngredients();
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
