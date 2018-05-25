using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManager.Migrations
{
    public partial class _003_InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_Menu_ParentIdId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_Menu_ParentIdId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Menu_ParentIdId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Menus",
                newName: "ParentIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentIdId",
                table: "Menus",
                column: "ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_ParentIdId",
                table: "Menus",
                column: "ParentIdId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Menus_ParentIdId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ParentIdId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "ParentIdId",
                table: "Menus",
                newName: "ParentId");

            migrationBuilder.AddColumn<Guid>(
                name: "Menu_ParentIdId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Menu_ParentIdId",
                table: "Menus",
                column: "Menu_ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Menus_Menu_ParentIdId",
                table: "Menus",
                column: "Menu_ParentIdId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
