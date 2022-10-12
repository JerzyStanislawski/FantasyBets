using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBets.Migrations
{
    public partial class bets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BetCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Odds = table.Column<decimal>(type: "TEXT", nullable: false),
                    BetTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetSelections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetSelections_BetType_BetTypeId",
                        column: x => x.BetTypeId,
                        principalTable: "BetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetSelections_BetTypeId",
                table: "BetSelections",
                column: "BetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BetSelections_UserId",
                table: "BetSelections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetSelections");

            migrationBuilder.DropTable(
                name: "BetType");
        }
    }
}
