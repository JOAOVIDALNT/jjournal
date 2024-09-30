using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jjournal.Infrastructure.Data.Mapping;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles")
            .HasKey(x => x.Uuid);
        
        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Content).IsRequired();
        
        builder.HasOne(article => article.Author)
            .WithMany(user => user.Articles)
            .HasForeignKey(article => article.AuthorId);
    }
}