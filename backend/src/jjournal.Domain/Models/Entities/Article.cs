using jjournal.Domain.Models.Entities.Base;

namespace jjournal.Domain.Models.Entities;

public class Article : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    public virtual User? Author { get; set; }
    public Guid AuthorId { get; set; }
}