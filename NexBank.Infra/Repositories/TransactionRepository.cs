using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Queries;
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

        public IEnumerable<Transaction> GetTransactions(DateTime dateFrom, DateTime dateTo, ETransactionType transactionType, Guid accountId)
        {
            return _context.Transactions
                .AsNoTracking()
                .Where(TransactionQueries.GetTransactions(dateFrom, dateTo, transactionType, accountId))
                .OrderBy(x => x.CreateDate);
        }

        public void SaveTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }
    }
}