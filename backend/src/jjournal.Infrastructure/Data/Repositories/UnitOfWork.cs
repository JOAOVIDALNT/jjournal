using jjournal.Domain.Interfaces.Repositories;

namespace jjournal.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db) => _db = db;
        public async Task Commit() => await _db.SaveChangesAsync();
    }
}
