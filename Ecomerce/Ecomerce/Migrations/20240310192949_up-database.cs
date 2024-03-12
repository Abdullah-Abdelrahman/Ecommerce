using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Migrations
{
    /// <inheritdoc />
    public partial class updatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_orders_OrderId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_OrderId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "customers");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "orders",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_customers_OrderId",
                table: "customers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_orders_OrderId",
                table: "customers",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
