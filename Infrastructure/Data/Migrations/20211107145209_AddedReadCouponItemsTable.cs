using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedReadCouponItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "ReadCoupons");

            migrationBuilder.CreateTable(
                name: "ReadCouponItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadCouponId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayTeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTeamGoals = table.Column<int>(type: "int", nullable: true),
                    AwayTeamGoals = table.Column<int>(type: "int", nullable: true),
                    HomeTeamGoalsExtraTime = table.Column<int>(type: "int", nullable: true),
                    AwayTeamGoalsExtraTime = table.Column<int>(type: "int", nullable: true),
                    HomeTeamGoalsPenalty = table.Column<int>(type: "int", nullable: true),
                    AwayTeamGoalsPenalty = table.Column<int>(type: "int", nullable: true),
                    MatchWinnerOption = table.Column<int>(type: "int", nullable: false),
                    Odd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadCouponItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadCouponItem_ReadCoupons_ReadCouponId",
                        column: x => x.ReadCouponId,
                        principalTable: "ReadCoupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadCouponItem_ReadCouponId",
                table: "ReadCouponItem",
                column: "ReadCouponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadCouponItem");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "ReadCoupons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
