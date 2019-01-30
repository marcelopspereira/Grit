using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class EmpNoteUp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeNotes_Employees_Employee",
                table: "EmployeeNotes");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeNotes_Employee",
                table: "EmployeeNotes");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "EmployeeNotes");

            migrationBuilder.AddColumn<int>(
                name: "EID",
                table: "EmployeeNotes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EID",
                table: "EmployeeNotes");

            migrationBuilder.AddColumn<int>(
                name: "Employee",
                table: "EmployeeNotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeNotes_Employee",
                table: "EmployeeNotes",
                column: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeNotes_Employees_Employee",
                table: "EmployeeNotes",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
