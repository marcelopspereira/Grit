using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class ViewModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientVM_ClientViewModelClientID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ClientVM");

            migrationBuilder.RenameColumn(
                name: "ClientViewModelClientID",
                table: "Employees",
                newName: "ClientVMClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ClientViewModelClientID",
                table: "Employees",
                newName: "IX_Employees_ClientVMClientID");

            migrationBuilder.CreateTable(
                name: "ClientVMs",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVMs", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectVMs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Attributes = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    AssignedClientIDClientID = table.Column<int>(nullable: true),
                    EmployeeIDEmpID = table.Column<int>(nullable: true),
                    EmpFullNameEmpID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVMs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectVMs_Clients_AssignedClientIDClientID",
                        column: x => x.AssignedClientIDClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectVMs_Employees_EmpFullNameEmpID",
                        column: x => x.EmpFullNameEmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectVMs_Employees_EmployeeIDEmpID",
                        column: x => x.EmployeeIDEmpID,
                        principalTable: "Employees",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVMs_AssignedClientIDClientID",
                table: "ProjectVMs",
                column: "AssignedClientIDClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVMs_EmpFullNameEmpID",
                table: "ProjectVMs",
                column: "EmpFullNameEmpID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVMs_EmployeeIDEmpID",
                table: "ProjectVMs",
                column: "EmployeeIDEmpID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientVMs_ClientVMClientID",
                table: "Employees",
                column: "ClientVMClientID",
                principalTable: "ClientVMs",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientVMs_ClientVMClientID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ClientVMs");

            migrationBuilder.DropTable(
                name: "ProjectVMs");

            migrationBuilder.RenameColumn(
                name: "ClientVMClientID",
                table: "Employees",
                newName: "ClientViewModelClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ClientVMClientID",
                table: "Employees",
                newName: "IX_Employees_ClientViewModelClientID");

            migrationBuilder.CreateTable(
                name: "ClientVM",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVM", x => x.ClientID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientVM_ClientViewModelClientID",
                table: "Employees",
                column: "ClientViewModelClientID",
                principalTable: "ClientVM",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
