using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpZleceniaWeb.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ranameGlowneTabele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "ZamowienieStatus");

            migrationBuilder.CreateTable(
                name: "ZlecenieStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZlecenieStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zlecenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Urzadzenie = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumerSer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TypUrzadzenia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OpisUsterki = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DataPrzyjecie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRozpoczRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataZakRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KlientImie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KlientNazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KlientNazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KlientTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZamowienieStatusId = table.Column<int>(type: "int", nullable: false),
                    KlientId = table.Column<int>(type: "int", nullable: false),
                    TypUrzadzeniaId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserWTrakcieId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserZakonczoneId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zlecenie_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenie_AspNetUsers_ApplicationUserWTrakcieId",
                        column: x => x.ApplicationUserWTrakcieId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zlecenie_AspNetUsers_ApplicationUserZakonczoneId",
                        column: x => x.ApplicationUserZakonczoneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zlecenie_Klient_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenie_TypUrzadzenia_TypUrzadzeniaId",
                        column: x => x.TypUrzadzeniaId,
                        principalTable: "TypUrzadzenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenie_ZlecenieStatus_ZamowienieStatusId",
                        column: x => x.ZamowienieStatusId,
                        principalTable: "ZlecenieStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ApplicationUserId",
                table: "Zlecenie",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ApplicationUserWTrakcieId",
                table: "Zlecenie",
                column: "ApplicationUserWTrakcieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ApplicationUserZakonczoneId",
                table: "Zlecenie",
                column: "ApplicationUserZakonczoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_KlientId",
                table: "Zlecenie",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_TypUrzadzeniaId",
                table: "Zlecenie",
                column: "TypUrzadzeniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenie_ZamowienieStatusId",
                table: "Zlecenie",
                column: "ZamowienieStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zlecenie");

            migrationBuilder.DropTable(
                name: "ZlecenieStatus");

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
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserWTrakcieId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationUserZakonczoneId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KlientId = table.Column<int>(type: "int", nullable: false),
                    TypUrzadzeniaId = table.Column<int>(type: "int", nullable: false),
                    ZamowienieStatusId = table.Column<int>(type: "int", nullable: false),
                    DataPrzyjecie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRozpoczRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataZakRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KlientImie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KlientNazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KlientNazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KlientTel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumerSer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OpisUsterki = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TypUrzadzenia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Urzadzenie = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
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
    }
}
