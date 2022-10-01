using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salary_management.Migrations
{
    public partial class UpdateQualification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_qualifications_staffs_staff_id",
                table: "qualifications");

            migrationBuilder.DropIndex(
                name: "ix_qualifications_staff_id",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "allowance",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "issue_date",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "place_of_issue",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "score",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "staff_id",
                table: "qualifications");

            migrationBuilder.CreateTable(
                name: "qualification_allowance_histories",
                columns: table => new
                {
                    year = table.Column<int>(type: "integer", nullable: false),
                    qualification_id = table.Column<int>(type: "integer", nullable: false),
                    allowance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_qualification_allowance_histories", x => new { x.qualification_id, x.year });
                    table.ForeignKey(
                        name: "fk_qualification_allowance_histories_qualifications_qualificat",
                        column: x => x.qualification_id,
                        principalTable: "qualifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staff_qualifications",
                columns: table => new
                {
                    qualification_id = table.Column<int>(type: "integer", nullable: false),
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    score = table.Column<float>(type: "real", nullable: false),
                    issue_date = table.Column<DateOnly>(type: "date", nullable: false),
                    place_of_issue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staff_qualifications", x => new { x.staff_id, x.qualification_id });
                    table.ForeignKey(
                        name: "fk_staff_qualifications_qualifications_qualification_id",
                        column: x => x.qualification_id,
                        principalTable: "qualifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staff_qualifications_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_staff_qualifications_qualification_id",
                table: "staff_qualifications",
                column: "qualification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "qualification_allowance_histories");

            migrationBuilder.DropTable(
                name: "staff_qualifications");

            migrationBuilder.AddColumn<int>(
                name: "allowance",
                table: "qualifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "issue_date",
                table: "qualifications",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "place_of_issue",
                table: "qualifications",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "score",
                table: "qualifications",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "staff_id",
                table: "qualifications",
                type: "character varying(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_qualifications_staff_id",
                table: "qualifications",
                column: "staff_id");

            migrationBuilder.AddForeignKey(
                name: "fk_qualifications_staffs_staff_id",
                table: "qualifications",
                column: "staff_id",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
