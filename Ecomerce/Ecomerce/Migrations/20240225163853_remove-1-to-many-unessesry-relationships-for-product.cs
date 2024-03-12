using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class remove1tomanyunessesryrelationshipsforproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_Categorias_Categoriy_Id",
                table: "ProductList");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_Sizes_SizeID",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_Categoriy_Id",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_SizeID",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "Categoriy_Id",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "ProductList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoriy_Id",
                table: "ProductList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "ProductList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_Categoriy_Id",
                table: "ProductList",
                column: "Categoriy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_SizeID",
                table: "ProductList",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_Categorias_Categoriy_Id",
                table: "ProductList",
                column: "Categoriy_Id",
                principalTable: "Categorias",
                principalColumn: "Categoriy_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_Sizes_SizeID",
                table: "ProductList",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID");
        }
    }
}
