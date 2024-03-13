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
			UpdatedAt = DateTime.UtcNow
		};
		await _userRepository.CreateAsync(dbUser);
	}
}
