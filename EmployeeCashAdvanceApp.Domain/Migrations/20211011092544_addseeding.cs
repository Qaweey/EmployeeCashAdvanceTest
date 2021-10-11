using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeCashAdvanceApp.Domain.Migrations
{
    public partial class addseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "HODEmail", "HODName" },
                values: new object[,]
                {
                    { 1, "IT", "soetanqaweey@gmail.com", "Qaweey Soetan" },
                    { 2, "HR", "Bisi@gmail.com", "Bisi Olatilo" },
                    { 3, "Finance", "Ogechi@gmail.com", "Ogechi Alari" },
                    { 4, "Marketing", "Halimat@gmail.com", "Halimat Oke" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);
        }
    }
}
