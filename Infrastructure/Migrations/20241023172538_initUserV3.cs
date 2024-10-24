using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initUserV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c082972-f54b-4875-a88f-aec2069a3440");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61c5be8d-72a7-4147-8562-7ec6bbf26bb6");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a330c5a-221f-4c1f-8787-db82aa99ef70", "2", "Customer", "CUSTOMER" },
                    { "384cc1ac-d52d-400f-8e70-791a96372a2d", "1", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a330c5a-221f-4c1f-8787-db82aa99ef70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "384cc1ac-d52d-400f-8e70-791a96372a2d");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c082972-f54b-4875-a88f-aec2069a3440", "1", "User", "USER" },
                    { "61c5be8d-72a7-4147-8562-7ec6bbf26bb6", "2", "Customer", "CUSTOMER" }
                });
        }
    }
}
