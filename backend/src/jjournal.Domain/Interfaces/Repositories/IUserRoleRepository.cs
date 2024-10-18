using jjournal.Domain.Models.Entities;

namespace jjournal.Domain.Interfaces.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task AddRoleToUser(User user, Role role);
    }
}
