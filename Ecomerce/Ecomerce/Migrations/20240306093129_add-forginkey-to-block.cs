using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class addforginkeytoblock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ProductList_Product_Id",
                table: "Blocks");

            migrationBuilder.AlterColumn<int>(
                name: "Product_Id",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ProductList_Product_Id",
                table: "Blocks",
                column: "Product_Id",
                principalTable: "ProductList",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ProductList_Product_Id",
                table: "Blocks");

            migrationBuilder.AlterColumn<int>(
                name: "Product_Id",
                table: "Blocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ProductList_Product_Id",
                table: "Blocks",
                column: "Product_Id",
                principalTable: "ProductList",
                principalColumn: "Product_Id");
        }
    }
}
