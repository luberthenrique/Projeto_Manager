using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Manager.api.Migrations
{
    public partial class criacao_bd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Left = table.Column<string>(nullable: true),
                    Right = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dado");
        }
    }
}
