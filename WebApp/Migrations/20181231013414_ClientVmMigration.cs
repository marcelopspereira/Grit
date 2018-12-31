using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class ClientVmMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientVM_Employees_AssignedEmpID",
                table: "ClientVM");

            migrationBuilder.DropIndex(
                name: "IX_ClientVM_AssignedEmpID",
                table: "ClientVM");

            migrationBuilder.DropColumn(
                name: "AssignedEmpID",
                table: "ClientVM");

            migrationBuilder.AddColumn<int>(
                name: "ClientViewModelClientID",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClientViewModelClientID",
                table: "Employees",
                column: "ClientViewModelClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientVM_ClientViewModelClientID",
                table: "Employees",
                column: "ClientViewModelClientID",
                principalTable: "ClientVM",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientVM_ClientViewModelClientID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClientViewModelClientID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientViewModelClientID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "AssignedEmpID",
                table: "ClientVM",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientVM_AssignedEmpID",
                table: "ClientVM",
                column: "AssignedEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientVM_Employees_AssignedEmpID",
                table: "ClientVM",
                column: "AssignedEmpID",
                principalTable: "Employees",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
