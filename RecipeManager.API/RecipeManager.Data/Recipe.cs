namespace RecipeManager.API.Data;

public class Recipe
{
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int TimeRequired { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
	    public required IDictionary<Ingredient, int> Ingredients { get; set; }
        public required IEnumerable<CookingStep> Steps { get; set; }
    }

public class Ingredient
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public string? ShortName { get; set; }
    public string? Description { get; set; }
}

public class CookingStep
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public int Minutes { get; set; }
}
