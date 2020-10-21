using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apontamento.App.Migrations
{
    public partial class projetos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("8aaa6ec8-66eb-43bc-aa7f-e1b4866ab0a0"));

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Horas = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Nome", "Senha", "Status" },
                values: new object[] { new Guid("f932d8b6-ff9b-4f2a-aeda-fb4408e549fe"), "admin@admin.com", "Administrador", "admin", true });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_EmpresaId",
                table: "Projeto",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("f932d8b6-ff9b-4f2a-aeda-fb4408e549fe"));

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Nome", "Senha", "Status" },
                values: new object[] { new Guid("8aaa6ec8-66eb-43bc-aa7f-e1b4866ab0a0"), "admin@admin.com", "Administrador", "admin", true });
        }
    }
}
