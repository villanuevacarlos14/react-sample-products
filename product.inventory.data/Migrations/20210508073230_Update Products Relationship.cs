using Microsoft.EntityFrameworkCore.Migrations;

namespace product.inventory.data.Migrations
{
    public partial class UpdateProductsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductInventories_ProductInventoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductInventoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductInventoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventories",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_Products_ProductId",
                table: "ProductInventories");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventories_ProductId",
                table: "ProductInventories");

            migrationBuilder.AddColumn<int>(
                name: "ProductInventoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductInventoryId",
                table: "Products",
                column: "ProductInventoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductInventories_ProductInventoryId",
                table: "Products",
                column: "ProductInventoryId",
                principalTable: "ProductInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
