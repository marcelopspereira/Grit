using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class ProjectVmMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpFullNameEmpID",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIDEmpID",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmpFullNameEmpID",
                table: "Projects",
                column: "EmpFullNameEmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeIDEmpID",
                table: "Projects",
                column: "EmployeeIDEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmpFullNameEmpID",
                table: "Projects",
                column: "EmpFullNameEmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeeIDEmpID",
                table: "Projects",
                column: "EmployeeIDEmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmpFullNameEmpID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeeIDEmpID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmpFullNameEmpID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmployeeIDEmpID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmpFullNameEmpID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeeIDEmpID",
                table: "Projects");
        }
    }
}
