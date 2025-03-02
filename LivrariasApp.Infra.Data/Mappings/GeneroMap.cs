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
    public class GeneroMap:IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("GENERO");
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome).IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.CadastradoEm).IsRequired();
            builder.Property(u => u.UltimaAtualizacaoEm).IsRequired();
        }
    }
}
