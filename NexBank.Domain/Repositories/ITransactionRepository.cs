
using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;

namespace NexBank.Domain.Repositories
{
    public interface ITransactionRepository
    {
        void SaveTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions(DateTime dateFrom, DateTime dateTo, ETransactionType transactionType, Guid accountId);
    }
}