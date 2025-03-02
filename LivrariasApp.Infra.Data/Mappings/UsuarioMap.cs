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
    public class UsuarioMap:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).HasColumnName("NOME").IsRequired().HasMaxLength(150);
            builder.Property(u => u.Email).HasColumnName("EMAIL").IsRequired().HasMaxLength(100);
            builder.Property(u => u.Senha).HasColumnName("SENHA").IsRequired().HasMaxLength(255);
            builder.Property(u => u.DataNascimento).HasColumnName("DATANASCIMENTO").IsRequired(false);
            builder.Property(u => u.IsAdmin).HasColumnName("ISADMIN").IsRequired();

            builder.Property(u => u.CadastradoEm).IsRequired();
            builder.Property(u => u.UltimaAtualizacaoEm).IsRequired();

            //mapeamento de índices
            builder.HasIndex(c => c.Email).IsUnique();

            builder.HasMany(u => u.Livros)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.UsuarioId);
        }
    }
}
