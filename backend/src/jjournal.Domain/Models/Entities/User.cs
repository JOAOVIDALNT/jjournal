using jjournal.Domain.Models.Entities.Base;

namespace jjournal.Domain.Models.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public virtual ICollection<Article> Articles { get; set; } = [];
    public virtual ICollection<UserRole> UserRoles { get; set; } = [];
}