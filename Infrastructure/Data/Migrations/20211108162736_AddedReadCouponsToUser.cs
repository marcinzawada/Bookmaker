using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedReadCouponsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReadCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReadCoupons_UserId",
                table: "ReadCoupons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadCoupons_Users_UserId",
                table: "ReadCoupons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadCoupons_Users_UserId",
                table: "ReadCoupons");

            migrationBuilder.DropIndex(
                name: "IX_ReadCoupons_UserId",
                table: "ReadCoupons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReadCoupons");
        }
    }
}
