using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos");

            migrationBuilder.DropIndex(
                name: "IX_ConjuntoAlunos_AlunoId",
                table: "ConjuntoAlunos");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "ConjuntoAlunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "ConjuntoAlunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConjuntoAlunos_AlunoId",
                table: "ConjuntoAlunos",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
