namespace RecipeManager.Data
{
	public class Comment
	{
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid CreatedFor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required string Text { get; set; }
    }
}
