using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removePoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenie_AspNetUsers_ApplicationUserWTrakcieId",
                table: "Zlecenie");

            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenie_AspNetUsers_ApplicationUserZakonczoneId",
                table: "Zlecenie");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenie_ApplicationUserWTrakcieId",
                table: "Zlecenie");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenie_ApplicationUserZakonczoneId",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "ApplicationUserWTrakcieId",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "ApplicationUserZakonczoneId",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "KlientImie",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "KlientNazwa",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "KlientNazwisko",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "KlientTel",
                table: "Zlecenie");

            migrationBuilder.DropColumn(
                name: "TypUrzadzenia",
                table: "Zlecenie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserWTrakcieId",
                table: "Zlecenie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserZakonczoneId",
                table: "Zlecenie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KlientImie",
                table: "Zlecenie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KlientNazwa",
                table: "Zlecenie",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KlientNazwisko",
                table: "Zlecenie",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KlientTel",
                table: "Zlecenie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypUrzadzenia",
                table: "Zlecenie",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ApplicationUserWTrakcieId",
                table: "Zlecenie",
                column: "ApplicationUserWTrakcieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ApplicationUserZakonczoneId",
                table: "Zlecenie",
                column: "ApplicationUserZakonczoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenie_AspNetUsers_ApplicationUserWTrakcieId",
                table: "Zlecenie",
                column: "ApplicationUserWTrakcieId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenie_AspNetUsers_ApplicationUserZakonczoneId",
                table: "Zlecenie",
                column: "ApplicationUserZakonczoneId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
