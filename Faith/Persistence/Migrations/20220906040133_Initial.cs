using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Begeleiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Geslacht = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Begeleiders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jongeren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begeleider = table.Column<int>(type: "int", nullable: false),
                    BegeleiderId = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Geslacht = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jongeren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jongeren_Begeleiders_BegeleiderId",
                        column: x => x.BegeleiderId,
                        principalTable: "Begeleiders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post = table.Column<int>(type: "int", nullable: false),
                    BegeleiderId = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Gebruiker = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactie_Begeleiders_BegeleiderId",
                        column: x => x.BegeleiderId,
                        principalTable: "Begeleiders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Onderwerp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archief = table.Column<bool>(type: "bit", nullable: false),
                    BegeleiderId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JongereId = table.Column<int>(type: "int", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Gebruiker = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Jongeren_JongereId",
                        column: x => x.JongereId,
                        principalTable: "Jongeren",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jongeren_BegeleiderId",
                table: "Jongeren",
                column: "BegeleiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_JongereId",
                table: "Posts",
                column: "JongereId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactie_BegeleiderId",
                table: "Reactie",
                column: "BegeleiderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Reactie");

            migrationBuilder.DropTable(
                name: "Jongeren");

            migrationBuilder.DropTable(
                name: "Begeleiders");
        }
    }
}
