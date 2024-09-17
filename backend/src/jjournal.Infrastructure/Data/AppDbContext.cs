using jjournal.Domain.Models.Entities;
using jjournal.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new ArticleMap());
    }
}