using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManager.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "users");
        }
    }
}
