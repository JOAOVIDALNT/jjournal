using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Infrastructure.Data.Repositories
{
    public class RoleRepository(AppDbContext db) : Repository<Role>(db), IRoleRepository
    {
        public async Task<bool> RoleExistsAsync(string name) => await dbSet.AnyAsync(x => x.Name == name);
    }
}
