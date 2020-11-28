using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdateAdministracaoHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_AdministracaoHorarios_AdministracaoHorarioId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Niveis_NivelId",
                table: "Turmas");

            migrationBuilder.AlterColumn<int>(
                name: "NivelId",
                table: "Turmas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdministracaoHorarioId",
                table: "Turmas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraInicio",
                table: "AdministracaoHorarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraFim",
                table: "AdministracaoHorarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_AdministracaoHorarios_AdministracaoHorarioId",
                table: "Turmas",
                column: "AdministracaoHorarioId",
                principalTable: "AdministracaoHorarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Niveis_NivelId",
                table: "Turmas",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_AdministracaoHorarios_AdministracaoHorarioId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Niveis_NivelId",
                table: "Turmas");

            migrationBuilder.AlterColumn<int>(
                name: "NivelId",
                table: "Turmas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AdministracaoHorarioId",
                table: "Turmas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "HoraInicio",
                table: "AdministracaoHorarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HoraFim",
                table: "AdministracaoHorarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_AdministracaoHorarios_AdministracaoHorarioId",
                table: "Turmas",
                column: "AdministracaoHorarioId",
                principalTable: "AdministracaoHorarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Niveis_NivelId",
                table: "Turmas",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
