using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.EntityConfig.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.EntityConfig
{
    public class DepartamentoMap : EntityTypeConfiguration<Departamento>
    {
        public override void Map(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.IdDepartamento);

            builder.Property(d => d.Descricao)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Ignore(d => d.Area);
            builder.HasOne(d => d.Area)
                .WithMany(d => d.Departamentos)
                .HasForeignKey(d => d.IdArea);
            
            builder.ToTable("TBL_STAR_Departamento");
        }
    }
}
