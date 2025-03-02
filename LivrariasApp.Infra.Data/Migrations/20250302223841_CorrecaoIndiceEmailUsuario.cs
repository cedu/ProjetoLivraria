using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoIndiceEmailUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimaAtualizacaoEm",
                table: "LIVRO",
                newName: "ULTIMAATUALIZACAOEM");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "LIVRO",
                newName: "TITULO");

            migrationBuilder.RenameColumn(
                name: "Sinopse",
                table: "LIVRO",
                newName: "SINOPSE");

            migrationBuilder.RenameColumn(
                name: "CaminhoImagem",
                table: "LIVRO",
                newName: "CAMINHOIMAGEM");

            migrationBuilder.RenameColumn(
                name: "CadastradoEm",
                table: "LIVRO",
                newName: "CADASTRADOEM");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "LIVRO",
                newName: "AUTOR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ULTIMAATUALIZACAOEM",
                table: "LIVRO",
                newName: "UltimaAtualizacaoEm");

            migrationBuilder.RenameColumn(
                name: "TITULO",
                table: "LIVRO",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "SINOPSE",
                table: "LIVRO",
                newName: "Sinopse");

            migrationBuilder.RenameColumn(
                name: "CAMINHOIMAGEM",
                table: "LIVRO",
                newName: "CaminhoImagem");

            migrationBuilder.RenameColumn(
                name: "CADASTRADOEM",
                table: "LIVRO",
                newName: "CadastradoEm");

            migrationBuilder.RenameColumn(
                name: "AUTOR",
                table: "LIVRO",
                newName: "Autor");
        }
    }
}
