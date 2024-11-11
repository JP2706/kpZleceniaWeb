using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6C9452D9-37CB-4B59-895A-912264382584", "F7B4916B-FFF7-4853-847C-2C4BDA3361A5", "Pracownik", "PRACOWNIK" },
                    { "CDBA0656-5628-48BD-A85E-321B11CBF6FB", "2F1171EE-0FB3-449D-BE46-9930B9CAFD51", "GlobalAdminstrator", "GLOBALADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6C9452D9-37CB-4B59-895A-912264382584");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CDBA0656-5628-48BD-A85E-321B11CBF6FB");
        }
    }
}
