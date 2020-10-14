using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookmaker.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Season = table.Column<int>(nullable: false),
                    SeasonStart = table.Column<DateTime>(nullable: true),
                    SeasonEnd = table.Column<DateTime>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true),
                    HasStandings = table.Column<bool>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    HasCoverageStandings = table.Column<bool>(nullable: false),
                    HasPlayers = table.Column<bool>(nullable: false),
                    HasTopScorers = table.Column<bool>(nullable: false),
                    HasPredictions = table.Column<bool>(nullable: false),
                    HasOdds = table.Column<bool>(nullable: false),
                    HasEvents = table.Column<bool>(nullable: false),
                    HasLineups = table.Column<bool>(nullable: false),
                    HasStatistics = table.Column<bool>(nullable: false),
                    HasPlayersStatistics = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
