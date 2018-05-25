using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManager.Migrations
{
    public partial class _004_InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentIdId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "ParentIdId",
                table: "Menus",
                newName: "ReportsToId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_ParentIdId",
                table: "Menus",
                newName: "IX_Menus_ReportsToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ReportsToId",
                table: "Menus",
                column: "ReportsToId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ReportsToId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "ReportsToId",
                table: "Menus",
                newName: "ParentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_ReportsToId",
                table: "Menus",
                newName: "IX_Menus_ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentIdId",
                table: "Menus",
                column: "ParentIdId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
