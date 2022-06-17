using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL_example.Migrations
{
    public partial class AddSeeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemList",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "To do list" });

            migrationBuilder.InsertData(
                table: "ItemData",
                columns: new[] { "Id", "Description", "Done", "ListId", "Title" },
                values: new object[] { 1, "Hahahahah", false, 1, "Testing data 1" });

            migrationBuilder.InsertData(
                table: "ItemData",
                columns: new[] { "Id", "Description", "Done", "ListId", "Title" },
                values: new object[] { 2, "Second one", true, 1, "Testing data 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemList",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
