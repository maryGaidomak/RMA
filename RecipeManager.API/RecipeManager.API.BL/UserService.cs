using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;
using RecipeManager.API.DataAccess.Interfaces;
using DAccess = RecipeManager.API.DataAccess;

namespace RecipeManager.API.BL;

public class UserService: IUserService
{
	private readonly IUserRepository _userRepository;
	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task CreateAsync(User user)
	{
		var dbUser = new DAccess.DataClasses.User() 
		{ 
			Email = user.Email, 
			FirstName = user.FirstName, 
			Username = user.Username,
			DateOfBirth = user.DateOfBirth,
			LastName = user.LastName,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
			IsDeleted = false
		};
		await _userRepository.CreateAsync(dbUser);
	}

	public bool Delete(Guid id)
	{
		return _userRepository.Delete(id);
	}

	public IEnumerable<User> GetAll()
	{
		return _userRepository.GetAll().Select(u => new User()
		{
			Id = u.Id,
			Email = u.Email, 
			FirstName = u.FirstName, 
			Username = u.Username,
			DateOfBirth = u.DateOfBirth,
			LastName = u.LastName,
			CreatedAt = u.CreatedAt,
			UpdatedAt = u.UpdatedAt
		});
	}

	public User GetById(Guid id)
	{
		var dbUser = _userRepository.GetById(id);
		if (dbUser is null)
			return null;

		return new User()
		{
			Id = dbUser.Id,
			Email = dbUser.Email,
			FirstName = dbUser.FirstName,
			Username = dbUser.Username,
			DateOfBirth = dbUser.DateOfBirth,
			LastName = dbUser.LastName,
			CreatedAt = dbUser.CreatedAt,
			UpdatedAt = dbUser.UpdatedAt
		};
	}

	public User? Search(string email)
	{
		return _userRepository.Search(email) is DAccess.DataClasses.User user ? new User()
		{
			Id = user.Id,
			Email = user.Email, 
			FirstName = user.FirstName, 
			Username = user.Username,
			DateOfBirth = user.DateOfBirth,
			LastName = user.LastName,
			CreatedAt = user.CreatedAt,
			UpdatedAt = user.UpdatedAt
		} : null;
	}

	public bool Update(User user)
	{
		return _userRepository.Update(new DAccess.DataClasses.User()
		{
			Id = user.Id,
			Email = user.Email,
			FirstName = user.FirstName,
			Username = user.Username,
			DateOfBirth = user.DateOfBirth,
			LastName = user.LastName
		});
	}
}
