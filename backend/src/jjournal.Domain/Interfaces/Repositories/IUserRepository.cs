using jjournal.Domain.Models.Entities;

namespace jjournal.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<bool> UserExists(string email);
    }
}
