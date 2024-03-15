using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RecipeManager.API.DataAccess.Contexts;
using RecipeManager.API.DataAccess.Contracts;

namespace RecipeManager.API.DataAccess;

public static class DbConfiguration
{
	public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<RecipeBookContext>(options =>
		   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped<IBaseRepository, BaseRepository>();
		services.AddScoped<IUserRepository, UserRepository>();

		var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
		var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(databaseName);

		services.AddSingleton<IMongoDatabase>(database);
		services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
		//services.AddSingleton<MongoDbContext>();

		return services;
	}
}
