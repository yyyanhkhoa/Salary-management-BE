using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salary_management.Migrations
{
    public partial class AuthUsernameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "ak_auths_username",
                table: "auths",
                column: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_auths_username",
                table: "auths");
        }
    }
}
