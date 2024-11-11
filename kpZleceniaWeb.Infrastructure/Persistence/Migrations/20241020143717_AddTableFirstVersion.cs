using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableFirstVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypUrzadzenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypUrzadzenia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZamowienieStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowienieStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Urzadzenie = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumerSer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TypUrzadzenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisUsterki = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DataPrzyjecie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRozpoczRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataZakRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KlientImie = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    KlientNazwisko = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    KlientNazwa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    KlientTel = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ZamowienieStatusId = table.Column<int>(type: "int", nullable: false),
                    KlientId = table.Column<int>(type: "int", nullable: false),
                    TypUrzadzeniaId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserWTrakcieId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserZakonczoneId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zamowienie_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_AspNetUsers_ApplicationUserWTrakcieId",
                        column: x => x.ApplicationUserWTrakcieId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zamowienie_AspNetUsers_ApplicationUserZakonczoneId",
                        column: x => x.ApplicationUserZakonczoneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_TypUrzadzenia_TypUrzadzeniaId",
                        column: x => x.TypUrzadzeniaId,
                        principalTable: "TypUrzadzenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienie_ZamowienieStatus_ZamowienieStatusId",
                        column: x => x.ZamowienieStatusId,
                        principalTable: "ZamowienieStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ApplicationUserId",
                table: "Zamowienie",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ApplicationUserWTrakcieId",
                table: "Zamowienie",
                column: "ApplicationUserWTrakcieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ApplicationUserZakonczoneId",
                table: "Zamowienie",
                column: "ApplicationUserZakonczoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KlientId",
                table: "Zamowienie",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_TypUrzadzeniaId",
                table: "Zamowienie",
                column: "TypUrzadzeniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_ZamowienieStatusId",
                table: "Zamowienie",
                column: "ZamowienieStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "TypUrzadzenia");

            migrationBuilder.DropTable(
                name: "ZamowienieStatus");
        }
    }
}
