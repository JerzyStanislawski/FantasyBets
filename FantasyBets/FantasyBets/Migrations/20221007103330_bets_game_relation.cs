using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBets.Migrations
{
    public partial class bets_game_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "BetSelections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BetSelections_GameId",
                table: "BetSelections",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetSelections_Game_GameId",
                table: "BetSelections");

            migrationBuilder.DropIndex(
                name: "IX_BetSelections_GameId",
                table: "BetSelections");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "BetSelections");
        }
    }
}
