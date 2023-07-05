using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBookWeb.Domain.Models;

namespace SimpleBookWeb.Infra.MappingRepo
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);

            entity.Property(x => x.Name)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasData(new Category() { Id = 1, Name = "Thriller" });
            entity.HasData(new Category() { Id = 2, Name = "History" });
            entity.HasData(new Category() { Id = 3, Name = "Drama" });
            entity.HasData(new Category() { Id = 4, Name = "Biography" });
        }
    }
}