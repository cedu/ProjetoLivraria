using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NovosCamposTabelaLivroGeneroEditora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "LIVRO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacaoEm",
                table: "LIVRO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "GENERO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacaoEm",
                table: "GENERO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "EDITORA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacaoEm",
                table: "EDITORA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "LIVRO");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacaoEm",
                table: "LIVRO");

            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "GENERO");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacaoEm",
                table: "GENERO");

            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "EDITORA");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacaoEm",
                table: "EDITORA");
        }
    }
}
