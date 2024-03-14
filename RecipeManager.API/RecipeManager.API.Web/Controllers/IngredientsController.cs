using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.BL.Interfaces;
using RecipeManager.API.Data;

namespace RecipeManager.API.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IngredientsController : ControllerBase
	{
		private readonly ILogger<IngredientsController> _logger;
		private readonly IIngredientService _ingredientService;

		public IngredientsController(IIngredientService ingredientService,
			ILogger<IngredientsController> logger)
		{
			_ingredientService = ingredientService;
			_logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> Create(Ingredient ingredient)
		{
			await _ingredientService.CreateAsync(ingredient);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var ingredients = await _ingredientService.GetAll();
			return Ok(ingredients);
		}
	}
}
