using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBets.Migrations
{
    public partial class indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Seasons_Code",
                table: "Seasons",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_Number",
                table: "Rounds",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_BetSelections_Result",
                table: "BetSelections",
                column: "Result");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seasons_Code",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_Number",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_BetSelections_Result",
                table: "BetSelections");
        }
    }
}
