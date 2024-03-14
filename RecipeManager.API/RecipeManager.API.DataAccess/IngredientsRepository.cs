using MongoDB.Driver;
using RecipeManager.API.DataAccess.Contexts;
using RecipeManager.API.DataAccess.Contracts;
using RecipeManager.API.DataAccess.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.API.DataAccess
{
	public class IngredientsRepository : IIngredientsRepository
	{
		private readonly MongoDbContext _context;

		public IngredientsRepository(MongoDbContext mongoDbContext) 
		{
			_context = mongoDbContext;
		}
		public async Task CreateIngredient(Ingredient ingredient)
		{
			await _context.Ingredients.InsertOneAsync(ingredient);
		}

		public Task<bool> DeleteIngredient(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Ingredient>> GetAllIngredients()
		{
			var filter = Builders<Ingredient>.Filter.Empty;
			var ingredients = await _context.Ingredients.Find(filter).ToListAsync();
			return ingredients;
		}

		public Task<Ingredient> GetIngredientById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Ingredient> GetIngredientByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateIngredient(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}
	}
}
