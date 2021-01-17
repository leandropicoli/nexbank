using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Repositories;

namespace NexBank.Tests.Repositories
{
    public class FakeTransactionRepository : ITransactionRepository
    {
        public IEnumerable<Transaction> GetTransactions(DateTime dateFrom, DateTime dateTo, ETransactionType transactionType, Guid accountId)
        {
            throw new NotImplementedException();
        }

        public void SaveTransaction(Transaction transaction)
        {
        }
    }
}