using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManager.API.DataAccess.DataClasses;

public class User
{
	[Column("id")]
	public Guid Id { get; set; }
	[Column("username")]
	public required string Username { get; set; }
	[Column("email")]
	public required string Email { get; set; }
	[Column("firstname")]
	public required string FirstName { get; set; }
	[Column("lastname")]
	public string? LastName { get; set; }
	[Column("dateofbirth")]
	public DateTime? DateOfBirth { get; set; }
	[Column("createdat")]
	public DateTime CreatedAt { get; set; }
	[Column("updatedat")]
	public DateTime UpdatedAt { get; set; }
	[Column("isdeleted")]
	public bool IsDeleted { get; set; }
}
