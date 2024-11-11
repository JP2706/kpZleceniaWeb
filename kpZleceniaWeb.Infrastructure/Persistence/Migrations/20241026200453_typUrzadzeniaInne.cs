using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class typUrzadzeniaInne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypUrzadzenia",
                columns: new[] { "Id", "Nazwa" },
                values: new object[] { 2, "Inne" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypUrzadzenia",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
