using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ConjuntoAlunos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Grades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Grades");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ConjuntoAlunos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
