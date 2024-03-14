using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;

namespace RecipeManager.API.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private readonly ILogger<UsersController> _logger;
	private readonly IUserService _userService;

	public UsersController(IUserService userService, ILogger<UsersController> logger)
	{
		_userService = userService;
		_logger = logger;
	}

	[HttpPost]
	public async Task<IActionResult> CreateAsync(User user)
	{
		_logger.LogInformation("Creating user");
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		await _userService.CreateAsync(user);
		return Ok();
	}

	[HttpPost]
	[Route("search")]
	public async Task<IActionResult> SearchAsync(string email)
	{
		var user = _userService.Search(email);
		if (user is null)
			return NotFound();
		return Ok(user);
	}


	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		var users = _userService.GetAll();
		return Ok(users);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAsync(User user)
	{
		_logger.LogInformation("Updating user");
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var result = _userService.Update(user);
		if (!result)
			return NotFound();
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteAsync(Guid id)
	{
		_logger.LogInformation("Deleting user");
		var result = _userService.Delete(id);
		if (!result)
			return NotFound();
		return Ok();
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> GetByIdAsync(Guid id)
	{
		var user = _userService.GetById(id);
		if (user is null)
			return NotFound();

		return Ok(user);
	}

}
