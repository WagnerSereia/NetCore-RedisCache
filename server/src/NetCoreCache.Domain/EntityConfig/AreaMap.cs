using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.EntityConfig.Extensions;

namespace NetCoreCache.Domain.EntityConfig
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public override void Map(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(a => a.IdArea);

            builder.Property(a => a.IdArea)
               .HasColumnName("id_area");

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(a => a.Status)
                .HasColumnName("status");
                    
            builder.ToTable("TBL_SICSV_AREA");
        }
    }
}
