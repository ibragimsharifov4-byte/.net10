using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BooknestConfiguration : IEntityTypeConfiguration<Booknest>
{
    public void Configure(EntityTypeBuilder<Booknest> entity)
    {
        entity.ToTable("booknest");
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(150);
    }
}
