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

            builder.Property(l => l.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(l => l.ISBN).IsRequired().HasMaxLength(20);
            builder.Property(l => l.Autor).IsRequired().HasMaxLength(255);
            builder.Property(l => l.Sinopse).HasMaxLength(5000);
            builder.Property(l => l.CaminhoImagem).HasMaxLength(500);

            builder.Property(u => u.CadastradoEm).IsRequired();
            builder.Property(u => u.UltimaAtualizacaoEm).IsRequired();

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
