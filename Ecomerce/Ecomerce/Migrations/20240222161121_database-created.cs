using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class databasecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Categoriy_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoriy_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoriy_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Categoriy_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.Product_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Block_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Block_Id);
                    table.ForeignKey(
                        name: "FK_Blocks_ProductList_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id");
                });

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
                name: "Styles",
                columns: table => new
                {
                    Style_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style_price = table.Column<int>(type: "int", nullable: true),
                    Product_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Style_Id);
                    table.ForeignKey(
                        name: "FK_Styles_ProductList_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "ProductList",
                        principalColumn: "Product_Id");
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Image_Id);
                    table.ForeignKey(
                        name: "FK_Images_Styles_Style_Id",
                        column: x => x.Style_Id,
                        principalTable: "Styles",
                        principalColumn: "Style_Id");
                });

            migrationBuilder.CreateTable(
                name: "Style_Sizes_Quantitys",
                columns: table => new
                {
                    style_size_quantityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Style_Id = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style_Sizes_Quantitys", x => x.style_size_quantityid);
                    table.ForeignKey(
                        name: "FK_Style_Sizes_Quantitys_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Style_Sizes_Quantitys_Styles_Style_Id",
                        column: x => x.Style_Id,
                        principalTable: "Styles",
                        principalColumn: "Style_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_Product_Id",
                table: "Blocks",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriyProduct_ProductsProduct_Id",
                table: "CategoriyProduct",
                column: "ProductsProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Style_Id",
                table: "Images",
                column: "Style_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductsProduct_Id",
                table: "ProductSize",
                column: "ProductsProduct_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Style_Sizes_Quantitys_SizeID",
                table: "Style_Sizes_Quantitys",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Style_Sizes_Quantitys_Style_Id",
                table: "Style_Sizes_Quantitys",
                column: "Style_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Product_Id",
                table: "Styles",
                column: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "CategoriyProduct");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Style_Sizes_Quantitys");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "ProductList");
        }
    }
}
