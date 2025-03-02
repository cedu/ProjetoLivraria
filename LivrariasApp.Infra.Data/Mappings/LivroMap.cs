using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariasApp.Infra.Data.Mappings
{
    public class LivroMap:IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("LIVRO");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo).HasColumnName("TITULO").IsRequired().HasMaxLength(255);
            builder.Property(l => l.ISBN).HasColumnName("ISBN").IsRequired().HasMaxLength(20);
            builder.Property(l => l.Autor).HasColumnName("AUTOR").IsRequired().HasMaxLength(255);
            builder.Property(l => l.Sinopse).HasColumnName("SINOPSE").HasMaxLength(5000);
            builder.Property(l => l.CaminhoImagem).HasColumnName("CAMINHOIMAGEM").HasMaxLength(500);

            builder.Property(l => l.CadastradoEm).HasColumnName("CADASTRADOEM").IsRequired().HasColumnType("datetime2");
            builder.Property(l => l.UltimaAtualizacaoEm).HasColumnName("ULTIMAATUALIZACAOEM").IsRequired().HasColumnType("datetime2");

            // Relacionamento: Um livro pertence a um usuário (N:1)
            builder.HasOne(l => l.Usuario)
                .WithMany(u => u.Livros)
                .HasForeignKey(l => l.UsuarioId);

            // Relacionamento: Um livro pertence a um gênero (N:1)
            builder.HasOne(l => l.Genero)
                .WithMany()
                .HasForeignKey(l => l.GeneroId);

            // Relacionamento: Um livro pertence a uma editora (N:1)
            builder.HasOne(l => l.Editora)
                .WithMany()
                .HasForeignKey(l => l.EditoraId);
        }
    }
}
