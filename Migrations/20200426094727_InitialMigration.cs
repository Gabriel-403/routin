using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace routin.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Introduction = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    EmployeeNo = table.Column<string>(maxLength: 10, nullable: false),
                    FistName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Dataofbrith = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyId", "Introduction", "Name" },
                values: new object[] { new Guid("bbdee09c-089d-4e30-be42-aaaabbdee09a"), new Guid("00000000-0000-0000-0000-000000000000"), "great compancy", "Micorsoft" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyId", "Introduction", "Name" },
                values: new object[] { new Guid("bbdee09c-089d-4e30-be42-aaaabbdee09b"), new Guid("00000000-0000-0000-0000-000000000000"), "no envy compancy", "google" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyId", "Introduction", "Name" },
                values: new object[] { new Guid("bbdee09c-089d-4e30-be42-aaaabbdee09c"), new Guid("00000000-0000-0000-0000-000000000000"), "Fubao", "aili" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
