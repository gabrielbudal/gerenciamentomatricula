using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWPF.Migrations
{
    public partial class UpdateContext4 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "ConjuntoAlunoId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ConjuntoAlunoId",
                table: "Alunos",
                column: "ConjuntoAlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Alunos",
                column: "ConjuntoAlunoId",
                principalTable: "ConjuntoAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ConjuntoAlunoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "ConjuntoAlunoId",
                table: "Alunos");

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
