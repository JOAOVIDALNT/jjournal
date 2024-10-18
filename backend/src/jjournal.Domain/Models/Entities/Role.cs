using jjournal.Domain.Models.Entities.Base;

namespace jjournal.Domain.Models.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}
