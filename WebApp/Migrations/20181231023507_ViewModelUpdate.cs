using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class ViewModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientVMClientID",
                table: "Note",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_ClientVMClientID",
                table: "Note",
                column: "ClientVMClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_ClientVMs_ClientVMClientID",
                table: "Note",
                column: "ClientVMClientID",
                principalTable: "ClientVMs",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_ClientVMs_ClientVMClientID",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ClientVMClientID",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ClientVMClientID",
                table: "Note");
        }
    }
}
