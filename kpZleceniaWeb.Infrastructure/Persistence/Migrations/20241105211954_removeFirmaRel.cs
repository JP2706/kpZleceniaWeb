using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeFirmaRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Firma_FirmaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FirmaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FirmaId",
                table: "AspNetUsers",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Firma_FirmaId",
                table: "AspNetUsers",
                column: "FirmaId",
                principalTable: "Firma",
                principalColumn: "Id");
        }
    }
}
