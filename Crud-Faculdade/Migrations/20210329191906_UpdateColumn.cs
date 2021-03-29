using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud_Faculdade.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Aluno_AlunoId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Disciplina_DisciplinaId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_AlunoId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_DisciplinaId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Disciplina");

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    DisciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunosId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplina_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DisciplinasId",
                table: "AlunoDisciplina",
                column: "DisciplinasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Disciplina",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Disciplina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_AlunoId",
                table: "Disciplina",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_DisciplinaId",
                table: "Disciplina",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Aluno_AlunoId",
                table: "Disciplina",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Disciplina_DisciplinaId",
                table: "Disciplina",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
