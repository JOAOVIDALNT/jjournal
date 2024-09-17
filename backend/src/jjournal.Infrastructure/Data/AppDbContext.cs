using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
}