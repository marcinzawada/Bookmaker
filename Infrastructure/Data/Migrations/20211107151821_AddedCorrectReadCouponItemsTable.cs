using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedCorrectReadCouponItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadCouponItem_ReadCoupons_ReadCouponId",
                table: "ReadCouponItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadCouponItem",
                table: "ReadCouponItem");

            migrationBuilder.RenameTable(
                name: "ReadCouponItem",
                newName: "ReadCouponItems");

            migrationBuilder.RenameIndex(
                name: "IX_ReadCouponItem_ReadCouponId",
                table: "ReadCouponItems",
                newName: "IX_ReadCouponItems_ReadCouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadCouponItems",
                table: "ReadCouponItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadCouponItems_ReadCoupons_ReadCouponId",
                table: "ReadCouponItems",
                column: "ReadCouponId",
                principalTable: "ReadCoupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadCouponItems_ReadCoupons_ReadCouponId",
                table: "ReadCouponItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadCouponItems",
                table: "ReadCouponItems");

            migrationBuilder.RenameTable(
                name: "ReadCouponItems",
                newName: "ReadCouponItem");

            migrationBuilder.RenameIndex(
                name: "IX_ReadCouponItems_ReadCouponId",
                table: "ReadCouponItem",
                newName: "IX_ReadCouponItem_ReadCouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadCouponItem",
                table: "ReadCouponItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadCouponItem_ReadCoupons_ReadCouponId",
                table: "ReadCouponItem",
                column: "ReadCouponId",
                principalTable: "ReadCoupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
