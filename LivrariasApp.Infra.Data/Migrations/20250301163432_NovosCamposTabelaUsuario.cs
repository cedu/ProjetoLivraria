using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NovosCamposTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "USUARIO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacaoEm",
                table: "USUARIO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacaoEm",
                table: "USUARIO");
        }
    }
}
