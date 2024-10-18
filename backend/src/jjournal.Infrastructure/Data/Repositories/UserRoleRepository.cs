using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Infrastructure.Data.Repositories
{
    public class UserRoleRepository(AppDbContext db) : Repository<UserRole>(db), IUserRoleRepository
    {
        public async Task AddRoleToUser(User user, Role role) => await dbSet.AddAsync(new UserRole {UserId = user.Uuid, RoleId = role.Uuid});
    }
}
