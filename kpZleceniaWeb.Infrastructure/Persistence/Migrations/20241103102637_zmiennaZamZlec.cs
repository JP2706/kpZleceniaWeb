using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class zmiennaZamZlec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenie_ZlecenieStatus_ZamowienieStatusId",
                table: "Zlecenie");

            migrationBuilder.RenameColumn(
                name: "ZamowienieStatusId",
                table: "Zlecenie",
                newName: "ZlecenieStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Zlecenie_ZamowienieStatusId",
                table: "Zlecenie",
                newName: "IX_Zlecenie_ZlecenieStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenie_ZlecenieStatus_ZlecenieStatusId",
                table: "Zlecenie",
                column: "ZlecenieStatusId",
                principalTable: "ZlecenieStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenie_ZlecenieStatus_ZlecenieStatusId",
                table: "Zlecenie");

            migrationBuilder.RenameColumn(
                name: "ZlecenieStatusId",
                table: "Zlecenie",
                newName: "ZamowienieStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Zlecenie_ZlecenieStatusId",
                table: "Zlecenie",
                newName: "IX_Zlecenie_ZamowienieStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenie_ZlecenieStatus_ZamowienieStatusId",
                table: "Zlecenie",
                column: "ZamowienieStatusId",
                principalTable: "ZlecenieStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
