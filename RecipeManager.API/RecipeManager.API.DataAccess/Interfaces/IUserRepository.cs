using RecipeManager.API.DataAccess.DataClasses;

namespace RecipeManager.API.DataAccess.Interfaces
{
	public interface IUserRepository
	{
		Task CreateAsync(User user);

		User Search(string email);
		IEnumerable<User> GetAll();

		User GetById(Guid id);
		bool Update(User user);
		bool Delete(Guid id);
	}
}
