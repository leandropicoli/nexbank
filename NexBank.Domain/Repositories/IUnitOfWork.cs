namespace NexBank.Domain.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}