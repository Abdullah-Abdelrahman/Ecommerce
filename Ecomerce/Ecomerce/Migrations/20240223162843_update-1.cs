using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriyProduct");

            migrationBuilder.DropTable(
                name: "ProductSize");

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

            migrationBuilder.CreateTable(
                name: "ProductCategoriys",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoriyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoriys", x => new { x.ProductId, x.CategoriyId });
                    table.ForeignKey(
                        name: "FK_ProductCategoriys_Categorias_CategoriyId",
                        column: x => x.CategoriyId,
                        principalTable: "Categorias",
                        principalColumn: "Categoriy_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoriys_ProductList_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productSizes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSizes", x => new { x.ProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_productSizes_ProductList_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_Categoriy_Id",
                table: "ProductList",
                column: "Categoriy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_SizeID",
                table: "ProductList",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoriys_CategoriyId",
                table: "ProductCategoriys",
                column: "CategoriyId");

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_SizeId",
                table: "productSizes",
                column: "SizeId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_Categorias_Categoriy_Id",
                table: "ProductList");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_Sizes_SizeID",
                table: "ProductList");

            migrationBuilder.DropTable(
                name: "ProductCategoriys");

            migrationBuilder.DropTable(
                name: "productSizes");

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

            migrationBuilder.CreateTable(
                name: "CategoriyProduct",
                columns: table => new
                {
                    Product_CategoriysCategoriy_Id = table.Column<int>(type: "int", nullable: false),
                    ProductsProduct_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriyProduct", x => new { x.Product_CategoriysCategoriy_Id, x.ProductsProduct_Id });
                    table.ForeignKey(
                        name: "FK_CategoriyProduct_Categorias_Product_CategoriysCategoriy_Id",
                        column: x => x.Product_CategoriysCategoriy_Id,
                        principalTable: "Categorias",
                        principalColumn: "Categoriy_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriyProduct_ProductList_ProductsProduct_Id",
                        column: x => x.ProductsProduct_Id,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Product_sizesSizeID = table.Column<int>(type: "int", nullable: false),
                    ProductsProduct_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => new { x.Product_sizesSizeID, x.ProductsProduct_Id });
                    table.ForeignKey(
                        name: "FK_ProductSize_ProductList_ProductsProduct_Id",
                        column: x => x.ProductsProduct_Id,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Sizes_Product_sizesSizeID",
                        column: x => x.Product_sizesSizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriyProduct_ProductsProduct_Id",
                table: "CategoriyProduct",
                column: "ProductsProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductsProduct_Id",
                table: "ProductSize",
                column: "ProductsProduct_Id");
        }
    }
}
