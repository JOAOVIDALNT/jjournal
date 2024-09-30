using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;

namespace jjournal.Infrastructure.Data.Repositories
{
    public class ArticleRepository(AppDbContext db) : Repository<Article>(db), IArticleRepository
    {
    }   
}
