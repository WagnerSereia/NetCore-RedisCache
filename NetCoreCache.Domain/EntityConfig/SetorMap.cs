using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.EntityConfig.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.EntityConfig
{
    public class SetorMap : EntityTypeConfiguration<Setor>
    {
        public override void Map(EntityTypeBuilder<Setor> builder)
        {
            builder.HasKey(s => s.IdSetor);

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Ignore(s => s.Departamento);
            builder.HasOne(s => s.Departamento)
                .WithMany(s => s.Setores)
                .HasForeignKey(s => s.IdDepartamento);

            builder.ToTable("TBL_STAR_Setor");
        }
    }
}
