using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Style_Sizes_Quantitys");

            migrationBuilder.CreateTable(
                name: "StyleSizes",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleSizes", x => new { x.StyleId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_StyleSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StyleSizes_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Style_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleSizes_SizeId",
                table: "StyleSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleSizes");

            migrationBuilder.CreateTable(
                name: "Style_Sizes_Quantitys",
                columns: table => new
                {
                    style_size_quantityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    Style_Id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Style_Sizes_Quantitys_SizeID",
                table: "Style_Sizes_Quantitys",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Style_Sizes_Quantitys_Style_Id",
                table: "Style_Sizes_Quantitys",
                column: "Style_Id");
        }
    }
}
