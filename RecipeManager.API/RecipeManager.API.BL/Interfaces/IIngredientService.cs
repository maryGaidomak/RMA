using RecipeManager.API.Data;
namespace RecipeManager.API.BL.Interfaces;

public interface IIngredientService
{
	Task CreateAsync (Ingredient ingredient);
	Task<IEnumerable<Ingredient>> GetAll();
	Ingredient? Search (string name);
	Ingredient GetById (Guid id);
	bool Update (Ingredient ingredient);
	bool Delete (Guid id);
}
