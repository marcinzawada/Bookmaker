using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedCreatedAtAndUpdatedAddToFixturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetValues_Bets_BetId",
                table: "BetValues");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Fixtures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Fixtures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PotentialBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    FixtureId = table.Column<int>(type: "int", nullable: false),
                    BookieId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotentialBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotentialBets_Bookies_BookieId",
                        column: x => x.BookieId,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotentialBets_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PotentialBets_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PotentialBets_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotentialBets_BookieId",
                table: "PotentialBets",
                column: "BookieId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialBets_FixtureId",
                table: "PotentialBets",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialBets_LabelId",
                table: "PotentialBets",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_PotentialBets_LeagueId",
                table: "PotentialBets",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetValues_PotentialBets_BetId",
                table: "BetValues",
                column: "BetId",
                principalTable: "PotentialBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetValues_PotentialBets_BetId",
                table: "BetValues");

            migrationBuilder.DropTable(
                name: "PotentialBets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Fixtures");

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookieId = table.Column<int>(type: "int", nullable: false),
                    FixtureId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Bookies_BookieId",
                        column: x => x.BookieId,
                        principalTable: "Bookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bets_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BookieId",
                table: "Bets",
                column: "BookieId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_FixtureId",
                table: "Bets",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_LabelId",
                table: "Bets",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_LeagueId",
                table: "Bets",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetValues_Bets_BetId",
                table: "BetValues",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
