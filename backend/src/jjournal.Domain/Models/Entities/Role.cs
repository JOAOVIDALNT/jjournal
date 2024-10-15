using jjournal.Domain.Models.Entities.Base;

namespace jjournal.Domain.Models.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
