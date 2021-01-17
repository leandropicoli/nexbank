using System;
using System.Linq.Expressions;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;

namespace NexBank.Domain.Queries
{
    public class TransactionQueries
    {
        public static Expression<Func<Transaction, bool>> GetTransactions(
            DateTime dateFrom,
            DateTime dateTo,
            ETransactionType transactionType,
            Guid accountId)
        {
            return x =>
                x.CreateDate >= dateFrom &&
                x.CreateDate <= dateTo &&
                x.TransactionType == transactionType &&
                x.AccountId == accountId;
        }
    }
}