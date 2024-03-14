using RecipeManager.API.DataAccess.Contexts;
using RecipeManager.API.DataAccess.Contracts;
using RecipeManager.API.DataAccess.DataClasses;

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

		public bool Delete(Guid id)
		{
			var dbUser = base._dbContext.users.Where(u => u.Id == id && !u.IsDeleted).FirstOrDefault();
			if (dbUser is null)
				return false;
			dbUser.IsDeleted = true;
			dbUser.UpdatedAt = DateTime.UtcNow;
			base._dbContext.SaveChanges();
			return true;
		}

		public IEnumerable<User> GetAll()
		{
			var users = base._dbContext.users.Where(u => !u.IsDeleted).ToList();
			return users;
		}

		public User GetById(Guid id)
		{
			return base._dbContext.users.Where(u => u.Id == id && !u.IsDeleted).FirstOrDefault();
		}

		public User Search(string email)
		{
			var user = base._dbContext.users.Where(u => u.Email == email && !u.IsDeleted).FirstOrDefault();
			return user;
		}

		public bool Update(User user)
		{
			var id = user.Id;
			var dbUser = base._dbContext.users.Where(u => u.Id == id && !u.IsDeleted).FirstOrDefault();
			if (dbUser is null)
				return false;
			dbUser.Email = user.Email;
			dbUser.FirstName = user.FirstName;
			dbUser.LastName = user.LastName;
			dbUser.Username = user.Username;
			dbUser.DateOfBirth = user.DateOfBirth;
			dbUser.UpdatedAt = DateTime.UtcNow;
			base._dbContext.SaveChanges();
			return true;
		}
	}
}
