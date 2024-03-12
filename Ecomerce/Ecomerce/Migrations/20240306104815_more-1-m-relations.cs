using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class more1mrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Styles_Style_Id",
                table: "Images");

           

            

            migrationBuilder.AlterColumn<int>(
                name: "Style_Id",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Styles_Style_Id",
                table: "Images",
                column: "Style_Id",
                principalTable: "Styles",
                principalColumn: "Style_Id",
                onDelete: ReferentialAction.Cascade);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Styles_Style_Id",
                table: "Images");

         


            migrationBuilder.AlterColumn<int>(
                name: "Style_Id",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Styles_Style_Id",
                table: "Images",
                column: "Style_Id",
                principalTable: "Styles",
                principalColumn: "Style_Id");

           
        }
    }
}
