using RecipeManager.API.BL.Interfaces;

namespace RecipeManager.API.BL;

public class BaseService : IBaseService
{
	public async Task<bool> IsAlive()
	{
		return true;
	}
}
