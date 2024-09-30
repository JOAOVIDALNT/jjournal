namespace jjournal.Domain.Models.Entities.Base;

public class BaseEntity
{
    public Guid Uuid { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}