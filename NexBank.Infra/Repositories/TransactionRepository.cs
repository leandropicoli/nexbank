using NexBank.Domain.Entities;
using NexBank.Domain.Repositories;
using NexBank.Infra.Contexts;

namespace NexBank.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public void SaveTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}