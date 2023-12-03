using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFInalExam.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateN = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PFE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PFE_Enseignant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_Societe_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PFE_ETUDIANT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE_ETUDIANT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PFE_ETUDIANT_Etudiants_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_ETUDIANT_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soutenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PFEID = table.Column<int>(type: "int", nullable: true),
                    PresidentId = table.Column<int>(type: "int", nullable: true),
                    RapporteurID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soutenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Enseignant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Soutenance_Enseignant_RapporteurID",
                        column: x => x.RapporteurID,
                        principalTable: "Enseignant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Soutenance_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFE_EncadrantID",
                table: "PFE",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_SocieteID",
                table: "PFE",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_ETUDIANT_EtudiantId",
                table: "PFE_ETUDIANT",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_ETUDIANT_PFEID",
                table: "PFE_ETUDIANT",
                column: "PFEID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PFEID",
                table: "Soutenance",
                column: "PFEID");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_PresidentId",
                table: "Soutenance",
                column: "PresidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soutenance_RapporteurID",
                table: "Soutenance",
                column: "RapporteurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PFE_ETUDIANT");

            migrationBuilder.DropTable(
                name: "Soutenance");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "PFE");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
