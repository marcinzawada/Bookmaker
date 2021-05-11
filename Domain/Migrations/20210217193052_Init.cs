using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtBookmakerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtLabelId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportId = table.Column<int>(nullable: false),
                    ExtLeagueId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    SeasonId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Leagues_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leagues_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leagues_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LeagueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtTeamId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    IsNational = table.Column<bool>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Founded = table.Column<int>(nullable: true),
                    VenueName = table.Column<string>(nullable: true),
                    VenueSurface = table.Column<string>(nullable: true),
                    VenueAddress = table.Column<string>(nullable: true),
                    VenueCity = table.Column<string>(nullable: true),
                    VenueCapacity = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Odd = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OddId = table.Column<int>(nullable: false),
                    BookieId = table.Column<int>(nullable: false),
                    LabelId = table.Column<int>(nullable: false)
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
                        name: "FK_Bets_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odds_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixtureId = table.Column<int>(nullable: false),
                    ExtFixtureId = table.Column<int>(nullable: true),
                    GoalsHomeTeam = table.Column<int>(nullable: true),
                    GoalsAwayTeam = table.Column<int>(nullable: true),
                    HalftimeHomeGoals = table.Column<int>(nullable: true),
                    HalftimeAwayGoals = table.Column<int>(nullable: true),
                    FullTimeHomeGoals = table.Column<int>(nullable: true),
                    FullTimeAwayGoals = table.Column<int>(nullable: true),
                    ExtraTimeHomeGoals = table.Column<int>(nullable: true),
                    ExtraTimeAwayGoals = table.Column<int>(nullable: true),
                    PenaltyHomeGoals = table.Column<int>(nullable: true),
                    PenaltyAwayGoals = table.Column<int>(nullable: true),
                    WinnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtFixtureId = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: true),
                    FirstHalfStart = table.Column<DateTime>(nullable: true),
                    SecondHalfStart = table.Column<DateTime>(nullable: true),
                    RoundId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(nullable: true),
                    Elapsed = table.Column<int>(nullable: true),
                    Venue = table.Column<string>(nullable: true),
                    Referee = table.Column<string>(nullable: true),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    ScoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixtures_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BookieId",
                table: "Bets",
                column: "BookieId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_LabelId",
                table: "Bets",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_OddId",
                table: "Bets",
                column: "OddId");

            migrationBuilder.CreateIndex(
                name: "IX_BetValues_BetId",
                table: "BetValues",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_LeagueId",
                table: "Fixtures",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_RoundId",
                table: "Fixtures",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_ScoreId",
                table: "Fixtures",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryId",
                table: "Leagues",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_SeasonId",
                table: "Leagues",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_SportId",
                table: "Leagues",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_FixtureId",
                table: "Odds",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_LeagueId",
                table: "Odds",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_LeagueId",
                table: "Rounds",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_FixtureId",
                table: "Score",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_WinnerId",
                table: "Score",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetValues_Bets_BetId",
                table: "BetValues",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Odds_OddId",
                table: "Bets",
                column: "OddId",
                principalTable: "Odds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Odds_Fixtures_FixtureId",
                table: "Odds",
                column: "FixtureId",
                principalTable: "Fixtures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Fixtures_FixtureId",
                table: "Score",
                column: "FixtureId",
                principalTable: "Fixtures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_AwayTeamId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Teams_HomeTeamId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Teams_WinnerId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Leagues_LeagueId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Leagues_LeagueId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Rounds_RoundId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Score_ScoreId",
                table: "Fixtures");

            migrationBuilder.DropTable(
                name: "BetValues");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Bookies");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Odds");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Fixtures");
        }
    }
}
