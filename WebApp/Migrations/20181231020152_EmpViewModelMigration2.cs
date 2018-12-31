using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class EmpViewModelMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeVMEmpID",
                table: "ProjectVMs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeVMEmpID",
                table: "ClientVMs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeVMs",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    EnumRoles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVMs", x => x.EmpID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVMs_EmployeeVMEmpID",
                table: "ProjectVMs",
                column: "EmployeeVMEmpID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientVMs_EmployeeVMEmpID",
                table: "ClientVMs",
                column: "EmployeeVMEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientVMs_EmployeeVMs_EmployeeVMEmpID",
                table: "ClientVMs",
                column: "EmployeeVMEmpID",
                principalTable: "EmployeeVMs",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectVMs_EmployeeVMs_EmployeeVMEmpID",
                table: "ProjectVMs",
                column: "EmployeeVMEmpID",
                principalTable: "EmployeeVMs",
                principalColumn: "EmpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientVMs_EmployeeVMs_EmployeeVMEmpID",
                table: "ClientVMs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectVMs_EmployeeVMs_EmployeeVMEmpID",
                table: "ProjectVMs");

            migrationBuilder.DropTable(
                name: "EmployeeVMs");

            migrationBuilder.DropIndex(
                name: "IX_ProjectVMs_EmployeeVMEmpID",
                table: "ProjectVMs");

            migrationBuilder.DropIndex(
                name: "IX_ClientVMs_EmployeeVMEmpID",
                table: "ClientVMs");

            migrationBuilder.DropColumn(
                name: "EmployeeVMEmpID",
                table: "ProjectVMs");

            migrationBuilder.DropColumn(
                name: "EmployeeVMEmpID",
                table: "ClientVMs");
        }
    }
}
