using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    TurmaId = table.Column<int>(nullable: true),
                    MentorDisciplinaId = table.Column<int>(nullable: true),
                    DiaId = table.Column<int>(nullable: true),
                    HorarioInicio = table.Column<string>(nullable: true),
                    HorarioFim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_MentorDisciplinas_MentorDisciplinaId",
                        column: x => x.MentorDisciplinaId,
                        principalTable: "MentorDisciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DiaId",
                table: "Grades",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_MentorDisciplinaId",
                table: "Grades",
                column: "MentorDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TurmaId",
                table: "Grades",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
