namespace jjournal.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
