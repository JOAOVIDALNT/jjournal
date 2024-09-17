using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jjournal.Infrastructure.Data.Mapping;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles")
            .HasKey(x => x.Id);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Address).IsRequired();
        
        builder.HasOne(a => a.Author)
            .WithMany(u => u.Articles)
            .HasForeignKey(a => a.AuthorId);
    }
}