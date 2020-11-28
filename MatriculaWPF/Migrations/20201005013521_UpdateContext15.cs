using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ConjuntoAlunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ConjuntoAlunos");
        }
    }
}
