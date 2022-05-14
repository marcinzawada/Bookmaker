using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class AddedResetPasswordTokenToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueTeams_Leagues_LeagueId",
                table: "LeagueTeams");

            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueTeams_Leagues_LeagueId",
                table: "LeagueTeams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueTeams_Leagues_LeagueId",
                table: "LeagueTeams");

            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueTeams_Leagues_LeagueId",
                table: "LeagueTeams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");
        }
    }
}
