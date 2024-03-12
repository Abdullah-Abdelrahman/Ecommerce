using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class removefromorderDitails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_ProductList_ProductId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_Sizes_SizeId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_Styles_StyleId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_SizeId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_StyleId",
                table: "orderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_SizeId",
                table: "orderDetails",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_StyleId",
                table: "orderDetails",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_ProductList_ProductId",
                table: "orderDetails",
                column: "ProductId",
                principalTable: "ProductList",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_Sizes_SizeId",
                table: "orderDetails",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_Styles_StyleId",
                table: "orderDetails",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Style_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
