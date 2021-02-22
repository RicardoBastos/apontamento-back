using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apontamento.Migrations
{
    public partial class usuarioativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("cb7cd87e-27ce-4bb7-979f-c201b5aff72f"));

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Usuario",
                newName: "Status");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Nome", "Senha", "Status" },
                values: new object[] { new Guid("8aaa6ec8-66eb-43bc-aa7f-e1b4866ab0a0"), "admin@admin.com", "Administrador", "admin", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: new Guid("8aaa6ec8-66eb-43bc-aa7f-e1b4866ab0a0"));

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Usuario",
                newName: "Ativo");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Email", "Nome", "Senha" },
                values: new object[] { new Guid("cb7cd87e-27ce-4bb7-979f-c201b5aff72f"), true, "admin@admin.com", "Administrador", "admin" });
        }
    }
}
