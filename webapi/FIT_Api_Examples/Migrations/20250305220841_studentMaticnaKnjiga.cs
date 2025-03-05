using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class studentMaticnaKnjiga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentMaticnaKnjiga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AkademskaGodinaId = table.Column<int>(type: "int", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    Obnova = table.Column<bool>(type: "bit", nullable: false),
                    DatumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumOvjere = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidentiraoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMaticnaKnjiga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMaticnaKnjiga_AkademskaGodina_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMaticnaKnjiga_KorisnickiNalog_EvidentiraoId",
                        column: x => x.EvidentiraoId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMaticnaKnjiga_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMaticnaKnjiga_AkademskaGodinaId",
                table: "StudentMaticnaKnjiga",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMaticnaKnjiga_EvidentiraoId",
                table: "StudentMaticnaKnjiga",
                column: "EvidentiraoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMaticnaKnjiga_StudentId",
                table: "StudentMaticnaKnjiga",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMaticnaKnjiga");
        }
    }
}
