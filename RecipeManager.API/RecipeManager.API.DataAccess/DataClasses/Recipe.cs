using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManager.API.DataAccess.DataClasses;
public class Recipe
{
	[Column("id")]
	public Guid Id { get; set; }
	[Column("name")]
	public required string Name { get; set; }
	[Column("timerequired")]
	public int TimeRequired { get; set; }
	[Column("createdby")]
	public Guid CreatedBy { get; set; }
	[Column("createdat")]
	public DateTime CreatedAt { get; set; }
	[Column("updatedat")]
	public DateTime UpdatedAt { get; set; }
	[Column("ingredients")]
	public required IDictionary<Ingredient, int> Ingredients { get; set; }
	[Column("steps")]
	public required IEnumerable<CookingStep> Steps { get; set; }
}

public class Ingredient
{
	[Column("id")]
	public Guid Id { get; set; }
	[Column("fullname")]
	public required string FullName { get; set; }
	[Column("shortname")]
	public string? ShortName { get; set; }
	[Column("description")]
	public string? Description { get; set; }
}

public class CookingStep
{
	[Column("id")]
	public Guid Id { get; set; }
	[Column("description")]
	public required string Description { get; set; }
	[Column("minutes")]
	public int Minutes { get; set; }
}
