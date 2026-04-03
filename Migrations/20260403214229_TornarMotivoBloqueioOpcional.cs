using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestao_de_Tarefas_Corporativas.Migrations
{
    /// <inheritdoc />
    public partial class TornarMotivoBloqueioOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotivoBloqueio",
                table: "Tarefas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotivoBloqueio",
                table: "Tarefas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
