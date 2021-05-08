using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace product.inventory.data.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CreatedDate", "Name", "Price", "UpdateDate" },
                values: new object[] { 1, "Samsung", new DateTime(2021, 5, 9, 2, 44, 12, 57, DateTimeKind.Local).AddTicks(7590), "Galaxy Tab 9", 35000m, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Password", "UpdateDate", "Username" },
                values: new object[] { 1, new DateTime(2021, 5, 9, 2, 44, 12, 56, DateTimeKind.Local).AddTicks(6200), "AQAAAAEAACcQAAAAEPUWCTyDoPaEBD4v1KZiaX/lMh0asrVvyW5ZuOIqjKo5ck8q26v2ySmvJIRar8yNlQ==", null, "admin" });

            migrationBuilder.InsertData(
                table: "ProductInventories",
                columns: new[] { "Id", "CreatedDate", "CurrentStock", "ProductId", "UpdateDate" },
                values: new object[] { 1, new DateTime(2021, 5, 9, 2, 44, 12, 57, DateTimeKind.Local).AddTicks(8850), 30, 1, null });

            migrationBuilder.InsertData(
                table: "ProductInventoryLogs",
                columns: new[] { "Id", "CreatedDate", "ProductInventoryId", "Quantity", "Type", "UpdateDate" },
                values: new object[] { 1, new DateTime(2021, 5, 9, 2, 44, 12, 58, DateTimeKind.Local).AddTicks(690), 1, 30, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInventoryLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductInventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
