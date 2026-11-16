using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Booknest> Booknests { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("authors");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Fullname).HasColumnName("fullname");
            entity.Property(x => x.Country).HasColumnName("country");
            entity.Property(x => x.Birthdate).HasColumnName("birthdate");
        });

        modelBuilder.Entity<Booknest>(entity =>
        {
            entity.ToTable("booknest");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Title).HasColumnName("title");
            entity.Property(x => x.CreateYear).HasColumnName("create_year");
            entity.Property(x => x.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name).HasColumnName("name");
        });

        base.OnModelCreating(modelBuilder);
    }
}
