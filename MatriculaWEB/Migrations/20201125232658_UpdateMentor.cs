using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaWEB.Migrations
{
    public partial class UpdateMentor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Mentor_MentorId",
                table: "MentorDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Mentor");

            migrationBuilder.RenameTable(
                name: "Mentor",
                newName: "Mentores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentores",
                table: "Mentores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas",
                column: "MentorId",
                principalTable: "Mentores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentorDisciplinas_Mentores_MentorId",
                table: "MentorDisciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentores",
                table: "Mentores");

            migrationBuilder.RenameTable(
                name: "Mentores",
                newName: "Mentor");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Mentor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorDisciplinas_Mentor_MentorId",
                table: "MentorDisciplinas",
                column: "MentorId",
                principalTable: "Mentor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
