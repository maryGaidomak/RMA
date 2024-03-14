using RecipeManager.API.DataAccess.DataClasses;

namespace RecipeManager.API.DataAccess.Contracts;

public interface IIngredientsRepository
{
	Task<IEnumerable<Ingredient>> GetAllIngredients();
	Task<Ingredient> GetIngredientByName(string name);
	Task<Ingredient> GetIngredientById(Guid id);
	Task CreateIngredient(Ingredient ingredient);
	Task<bool> UpdateIngredient(Ingredient ingredient);
	Task<bool> DeleteIngredient(Guid id);
}
