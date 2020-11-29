using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdateGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Dias_DiaId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_MentorDisciplinas_MentorDisciplinaId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Turmas_TurmaId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MentorDisciplinaId",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiaId",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Dias_DiaId",
                table: "Grades",
                column: "DiaId",
                principalTable: "Dias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_MentorDisciplinas_MentorDisciplinaId",
                table: "Grades",
                column: "MentorDisciplinaId",
                principalTable: "MentorDisciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Turmas_TurmaId",
                table: "Grades",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Dias_DiaId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_MentorDisciplinas_MentorDisciplinaId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Turmas_TurmaId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MentorDisciplinaId",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DiaId",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Dias_DiaId",
                table: "Grades",
                column: "DiaId",
                principalTable: "Dias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_MentorDisciplinas_MentorDisciplinaId",
                table: "Grades",
                column: "MentorDisciplinaId",
                principalTable: "MentorDisciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Turmas_TurmaId",
                table: "Grades",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
