using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "MentorDisciplinas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ConjuntoAlunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "MentorDisciplinas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ConjuntoAlunos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
