using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Salary_management.Migrations
{
    public partial class AddROD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reward_or_disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_reward = table.Column<bool>(type: "boolean", nullable: false),
                    level = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reward_or_disciplines", x => x.id);
                    table.ForeignKey(
                        name: "fk_reward_or_disciplines_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_reward_or_disciplines_staff_id",
                table: "reward_or_disciplines",
                column: "staff_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reward_or_disciplines");
        }
    }
}
