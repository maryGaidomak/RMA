using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
		services.AddScoped<IIngredientsRepository, IngredientsRepository>();
		services.AddSingleton<MongoDbContext>();

		return services;
	}
}
