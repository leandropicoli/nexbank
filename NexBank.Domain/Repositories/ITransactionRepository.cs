
using NexBank.Domain.Entities;

namespace NexBank.Domain.Repositories
{
    public interface ITransactionRepository
    {
        void SaveTransaction(Transaction transaction);
    }
}