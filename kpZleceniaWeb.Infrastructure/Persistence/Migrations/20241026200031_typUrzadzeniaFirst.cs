using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class typUrzadzeniaFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypUrzadzenia",
                columns: new[] { "Id", "Nazwa" },
                values: new object[] { 1, "Brak Typu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypUrzadzenia",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
