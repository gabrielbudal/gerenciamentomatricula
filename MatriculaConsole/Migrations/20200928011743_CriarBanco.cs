using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaConsole.Migrations
{
    public partial class CriarBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.DisciplinaId);
                });

            migrationBuilder.CreateTable(
                name: "Mentores",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentores", x => x.MentorId);
                });

            migrationBuilder.CreateTable(
                name: "MentorDisciplinas",
                columns: table => new
                {
                    MentorDisciplinasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorId = table.Column<int>(nullable: true),
                    DisciplinaId = table.Column<int>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorDisciplinas", x => x.MentorDisciplinasId);
                    table.ForeignKey(
                        name: "FK_MentorDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MentorDisciplinas_Mentores_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentores",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorDisciplinas_DisciplinaId",
                table: "MentorDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorDisciplinas_MentorId",
                table: "MentorDisciplinas",
                column: "MentorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorDisciplinas");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Mentores");
        }
    }
}
