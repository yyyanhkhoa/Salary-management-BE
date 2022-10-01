using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salary_management.Migrations
{
    public partial class SeedAdminAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "auths",
                columns: new[] { "id", "password", "username" },
                values: new object[] { 1, "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "auths",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
