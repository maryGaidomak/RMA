using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;

namespace RecipeManager.API.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IBaseService _baseService;
		private readonly IUserService _userService;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, 
			IBaseService baseService, IUserService userService)
		{
			_logger = logger;
			_baseService = baseService;
			_userService = userService;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpGet]
		[Route("IsAlive")]
		public async Task<bool> CheckIsAlive()
		{
			return await _baseService.IsAlive();
		}

		[HttpPost]
		[Route("createUser")]
		public async Task CreateUser(User user)
		{
			await _userService.CreateAsync(user);
		}
	}
}
