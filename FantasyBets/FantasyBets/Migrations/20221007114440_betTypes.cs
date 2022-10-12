using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBets.Migrations
{
    public partial class betTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_AspNetUsers_UserId",
                table: "BetSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_BetType_BetTypeId",
                table: "BetSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BetType",
                table: "BetType");

            migrationBuilder.RenameTable(
                name: "BetType",
                newName: "BetTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BetTypes",
                table: "BetTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_AspNetUsers_UserId",
                table: "BetSelections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_BetTypes_BetTypeId",
                table: "BetSelections",
                column: "BetTypeId",
                principalTable: "BetTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_AspNetUsers_UserId",
                table: "BetSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_BetTypes_BetTypeId",
                table: "BetSelections");

            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BetTypes",
                table: "BetTypes");

            migrationBuilder.RenameTable(
                name: "BetTypes",
                newName: "BetType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BetType",
                table: "BetType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_AspNetUsers_UserId",
                table: "BetSelections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_BetType_BetTypeId",
                table: "BetSelections",
                column: "BetTypeId",
                principalTable: "BetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
