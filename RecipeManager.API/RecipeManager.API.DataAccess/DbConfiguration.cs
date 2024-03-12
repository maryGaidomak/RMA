using Microsoft.Extensions.DependencyInjection;
using RecipeManager.API.DataAccess.Interfaces;

namespace RecipeManager.API.DataAccess;

public static class DbConfiguration
{
	public static IServiceCollection Configure(IServiceCollection services)
	{
		services.AddScoped<IBaseRepository, BaseRepository>();
		return services;
	}
}
