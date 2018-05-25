using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManager.Migrations
{
    public partial class _002_InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_Menu2Id",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "Menu2Id",
                table: "Menus",
                newName: "Menu_ParentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_Menu2Id",
                table: "Menus",
                newName: "IX_Menus_Menu_ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_Menu_ParentIdId",
                table: "Menus",
                column: "Menu_ParentIdId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_Menu_ParentIdId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "Menu_ParentIdId",
                table: "Menus",
                newName: "Menu2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_Menu_ParentIdId",
                table: "Menus",
                newName: "IX_Menus_Menu2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_Menu2Id",
                table: "Menus",
                column: "Menu2Id",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
