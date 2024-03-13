using RecipeManager.API.DataAccess.DataClasses;
using RecipeManager.API.DataAccess.Interfaces;

namespace RecipeManager.API.DataAccess
{
	public class UserRepository : BaseRepository, IUserRepository
	{
		public UserRepository(RecipeBookContext context) : base(context)
		{
		}

		public async Task CreateAsync(User user)
		{
			await base.CreateAsync(user);
		}
	}
}
