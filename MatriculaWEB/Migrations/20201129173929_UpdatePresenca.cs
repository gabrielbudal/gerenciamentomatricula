using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdatePresenca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Presencas");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Grades_GradeId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Presencas");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "Presencas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConjuntoAlunoId",
                table: "Presencas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Presencas",
                column: "ConjuntoAlunoId",
                principalTable: "ConjuntoAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Grades_GradeId",
                table: "Presencas",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Presencas");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Grades_GradeId",
                table: "Presencas");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "Presencas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ConjuntoAlunoId",
                table: "Presencas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Presencas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_ConjuntoAlunos_ConjuntoAlunoId",
                table: "Presencas",
                column: "ConjuntoAlunoId",
                principalTable: "ConjuntoAlunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Grades_GradeId",
                table: "Presencas",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
