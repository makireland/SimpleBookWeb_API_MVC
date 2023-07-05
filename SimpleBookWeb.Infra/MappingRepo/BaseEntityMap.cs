using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleBookWeb.Infra.MappingRepo
{
    public class BaseEntityMap<TEntityType> : IEntityTypeConfiguration<TEntityType> where TEntityType : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
        {
            builder.HasKey(x => x.GetType());
        }
    }
}
