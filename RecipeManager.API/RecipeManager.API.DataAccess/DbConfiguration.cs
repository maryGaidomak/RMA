using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeManager.API.DataAccess.Interfaces;

namespace RecipeManager.API.DataAccess;

public static class DbConfiguration
{
	public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<RecipeBookContext>(options =>
		   options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		services.AddScoped<IBaseRepository, BaseRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		

		return services;
	}
}
