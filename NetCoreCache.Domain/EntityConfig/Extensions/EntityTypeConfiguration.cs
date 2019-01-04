
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCoreCache.Domain.EntityConfig.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
