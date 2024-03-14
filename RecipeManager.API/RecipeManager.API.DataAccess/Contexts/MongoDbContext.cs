using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RecipeManager.API.DataAccess.DataClasses;

namespace RecipeManager.API.DataAccess.Contexts;

public class MongoDbContext
{
	private readonly IMongoDatabase _database;

	public MongoDbContext(IConfiguration configuration)
	{
		var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
		var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;
		var client = new MongoClient(connectionString);
		_database = client.GetDatabase(databaseName);
	}

	public IMongoCollection<Recipe> Recipes => _database.GetCollection<Recipe>("recipes");
	public IMongoCollection<Ingredient> Ingredients => _database.GetCollection<Ingredient>("ingredients");
	public IMongoCollection<CookingStep> CookingSteps => _database.GetCollection<CookingStep>("cookingsteps");
}
