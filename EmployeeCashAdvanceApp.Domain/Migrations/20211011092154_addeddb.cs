using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeCashAdvanceApp.Domain.Migrations
{
    public partial class addeddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HODName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HODEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

           

            migrationBuilder.CreateTable(
                name: "Employeedetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Amount = table.Column<string>(type: "varchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeedetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employeedetails_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Employeedetails_DepartmentId",
                table: "Employeedetails",
                column: "DepartmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Employeedetails");

           

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
