using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jjournal.Infrastructure.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(x => x.Id);
        
        builder.Property(x => x.Name).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(100);
    }
}