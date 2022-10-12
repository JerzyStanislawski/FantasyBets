using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBets.Migrations
{
    public partial class betTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "BetSelections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "BetSelections");
        }
    }
}
