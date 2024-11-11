using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFirma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Firma_FirmaId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FirmaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "AspNetUsers");
        }
    }
}
