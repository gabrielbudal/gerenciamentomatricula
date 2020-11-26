using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdateMentorDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Disciplinas_DisciplinaId",
                table: "MentorDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId",
                table: "MentorDisciplinas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisciplinaId",
                table: "MentorDisciplinas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Disciplinas_DisciplinaId",
                table: "MentorDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas",
                column: "MentorId",
                principalTable: "Mentores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Disciplinas_DisciplinaId",
                table: "MentorDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId",
                table: "MentorDisciplinas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DisciplinaId",
                table: "MentorDisciplinas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Disciplinas_DisciplinaId",
                table: "MentorDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas",
                column: "MentorId",
                principalTable: "Mentores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
