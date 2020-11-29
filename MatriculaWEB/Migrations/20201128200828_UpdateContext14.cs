using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdateContext14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_ConjuntoAlunos_Turmas_TurmaId",
                table: "ConjuntoAlunos");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "ConjuntoAlunos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "ConjuntoAlunos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConjuntoAlunos_Turmas_TurmaId",
                table: "ConjuntoAlunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_ConjuntoAlunos_Turmas_TurmaId",
                table: "ConjuntoAlunos");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "ConjuntoAlunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "ConjuntoAlunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ConjuntoAlunos_Alunos_AlunoId",
                table: "ConjuntoAlunos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConjuntoAlunos_Turmas_TurmaId",
                table: "ConjuntoAlunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
