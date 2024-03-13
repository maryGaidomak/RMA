using RecipeManager.API.DataAccess.DataClasses;

namespace RecipeManager.API.DataAccess.Interfaces
{
	public interface IUserRepository
	{
		Task CreateAsync(User user);
	}
}
