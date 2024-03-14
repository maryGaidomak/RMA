using RecipeManager.API.Data;

namespace RecipeManager.API.BL.Interfaces
{
	public interface IUserService
	{
		Task CreateAsync (User user);

		IEnumerable<User> GetAll();
		User? Search (string email);

		User GetById (Guid id);
		bool Update (User user);
		bool Delete (Guid id);
	}
}
