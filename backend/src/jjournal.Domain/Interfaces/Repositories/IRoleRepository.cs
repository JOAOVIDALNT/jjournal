using jjournal.Domain.Models.Entities;

namespace jjournal.Domain.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<bool> RoleExistsAsync(string name);
    }
}
