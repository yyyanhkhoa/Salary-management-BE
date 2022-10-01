using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Salary_management.Infrastructure.Entities.Enums;

#nullable disable

namespace Salary_management.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender", "male,female,other")
                .Annotation("Npgsql:Enum:relative_type", "wife,husband,child");

            migrationBuilder.CreateTable(
                name: "expertise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_expertise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rank",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    milestone = table.Column<int>(type: "integer", nullable: false),
                    coefficient = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    gender = table.Column<Gender>(type: "gender", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    ethnic = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    identity_card_number = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    coefficient_allowance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "union",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_union", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    date_founded = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    base_salary = table.Column<int>(type: "integer", nullable: false),
                    rank_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.id);
                    table.ForeignKey(
                        name: "fk_positions_rank_rank_id",
                        column: x => x.rank_id,
                        principalTable: "rank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qualifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    score = table.Column<float>(type: "real", nullable: false),
                    issue_date = table.Column<DateOnly>(type: "date", nullable: false),
                    place_of_issue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    allowance = table.Column<int>(type: "integer", nullable: false),
                    expertise_id = table.Column<int>(type: "integer", nullable: false),
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_qualifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_qualifications_expertise_expertise_id",
                        column: x => x.expertise_id,
                        principalTable: "expertise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_qualifications_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relatives",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    occupation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    relative_type = table.Column<RelativeType>(type: "relative_type", nullable: false),
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relatives", x => x.id);
                    table.ForeignKey(
                        name: "fk_relatives_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "union_history",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    union_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_union_history", x => new { x.staff_id, x.union_id });
                    table.ForeignKey(
                        name: "fk_union_history_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_union_history_union_union_id",
                        column: x => x.union_id,
                        principalTable: "union",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unit_histories",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    unit_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unit_histories", x => new { x.staff_id, x.unit_id });
                    table.ForeignKey(
                        name: "fk_unit_histories_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_unit_histories_unit_unit_id",
                        column: x => x.unit_id,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "position_histories",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    position_id = table.Column<string>(type: "character varying(255)", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_position_histories", x => new { x.staff_id, x.position_id });
                    table.ForeignKey(
                        name: "fk_position_histories_positions_position_id",
                        column: x => x.position_id,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_position_histories_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_position_histories_position_id",
                table: "position_histories",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "ix_positions_rank_id",
                table: "positions",
                column: "rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_qualifications_expertise_id",
                table: "qualifications",
                column: "expertise_id");

            migrationBuilder.CreateIndex(
                name: "ix_qualifications_staff_id",
                table: "qualifications",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "ix_relatives_staff_id",
                table: "relatives",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "ix_union_history_union_id",
                table: "union_history",
                column: "union_id");

            migrationBuilder.CreateIndex(
                name: "ix_unit_histories_unit_id",
                table: "unit_histories",
                column: "unit_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "position_histories");

            migrationBuilder.DropTable(
                name: "qualifications");

            migrationBuilder.DropTable(
                name: "relatives");

            migrationBuilder.DropTable(
                name: "union_history");

            migrationBuilder.DropTable(
                name: "unit_histories");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "expertise");

            migrationBuilder.DropTable(
                name: "union");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "rank");
        }
    }
}
