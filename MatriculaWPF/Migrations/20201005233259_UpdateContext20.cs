using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presencas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ConjuntoAlunoId = table.Column<int>(nullable: true),
                    GradeId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Presente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presencas_ConjuntoAlunos_ConjuntoAlunoId",
                        column: x => x.ConjuntoAlunoId,
                        principalTable: "ConjuntoAlunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presencas_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_ConjuntoAlunoId",
                table: "Presencas",
                column: "ConjuntoAlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_GradeId",
                table: "Presencas",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Presencas");
        }
    }
}
