using jjournal.Api.Data.Configs.Mappings;
using jjournal.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Api.Data.Configs
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
        }
    }
}
