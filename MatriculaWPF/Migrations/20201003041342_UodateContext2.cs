using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UodateContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministracaoHorarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    HoraFim = table.Column<string>(nullable: true),
                    HoraInicio = table.Column<string>(nullable: true),
                    TotalAulas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministracaoHorarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    AdministracaoHorarioId = table.Column<int>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    NivelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_AdministracaoHorarios_AdministracaoHorarioId",
                        column: x => x.AdministracaoHorarioId,
                        principalTable: "AdministracaoHorarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AdministracaoHorarioId",
                table: "Turmas",
                column: "AdministracaoHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_NivelId",
                table: "Turmas",
                column: "NivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "AdministracaoHorarios");
        }
    }
}
