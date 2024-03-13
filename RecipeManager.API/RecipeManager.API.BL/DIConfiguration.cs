using Microsoft.Extensions.DependencyInjection;
using RecipeManager.API.BL.Interfaces;

namespace RecipeManager.API.BL
{
	public static class DIConfiguration
	{
		public static IServiceCollection Configure(IServiceCollection services)
		{
			services.AddScoped<IBaseService, BaseService>();
			services.AddScoped<IUserService, UserService>();
			return services;
		}
	}
}
