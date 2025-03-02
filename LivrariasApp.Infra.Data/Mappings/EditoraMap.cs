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
    public class EditoraMap:IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.ToTable("EDITORA");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome).IsRequired().HasMaxLength(255);

            builder.Property(u => u.CadastradoEm).IsRequired();
            builder.Property(u => u.UltimaAtualizacaoEm).IsRequired();
        }
    }
}
