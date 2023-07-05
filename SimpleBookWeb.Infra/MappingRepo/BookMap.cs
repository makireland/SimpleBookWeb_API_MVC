using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBookWeb.Domain.Models;

namespace SimpleBookWeb.Infra.MappingRepo
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

            entity.Property(x => x.Author)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.Registration);

            entity.Property(x => x.Description)
                .IsUnicode(false)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}
