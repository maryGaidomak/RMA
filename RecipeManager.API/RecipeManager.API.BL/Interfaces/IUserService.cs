using RecipeManager.API.Data;

namespace RecipeManager.API.BL.Interfaces
{
	public interface IUserService
	{
		Task CreateAsync (User user);
	}
}
