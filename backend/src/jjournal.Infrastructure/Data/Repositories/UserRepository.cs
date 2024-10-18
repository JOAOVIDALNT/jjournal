using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace jjournal.Infrastructure.Data.Repositories
{
    /*
     Contrutor primário para a herança de Repository do tipo T = User, com isso herdamos o contexto definido pelo repositório genérico 
     */
    public class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
    {
        public async Task<bool> UserExists(string email) => await _db.Users.AnyAsync(u => u.Email.Equals(email));
        public async Task<User> GetUserWithRolesAsync(string email) => await dbSet.Include(u => u.UserRoles)
                                                                            .ThenInclude(ur => ur.Role)
                                                                            .FirstAsync(u => u.Email.Equals(email));
    }
}
