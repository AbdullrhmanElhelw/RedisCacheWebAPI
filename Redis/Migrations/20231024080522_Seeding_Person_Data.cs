using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Redis.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Person_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 20, "John" },
                    { 2, 30, "Jane" },
                    { 3, 40, "Jack" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
