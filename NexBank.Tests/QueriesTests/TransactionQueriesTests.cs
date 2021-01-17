using System;
using System.Collections.Generic;
using System.Linq;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Queries;
using Xunit;

namespace NexBank.Tests.QueriesTests
{
    public class TransactionQueriesTests
    {
        private List<Transaction> _transactions;
        private Account _account1;
        private Account _account2;

        public TransactionQueriesTests()
        {
            _account1 = new Account("test", "1214");
            _account2 = new Account("foo", "1234");

            _transactions = new List<Transaction>();

            _transactions.Add(new Transaction(_account1.Id, "desc", ETransactionType.Credit, 100M, 100M));
            _transactions.Add(new Transaction(_account1.Id, "desc", ETransactionType.Debit, 100M, 100M));
            _transactions.Add(new Transaction(_account1.Id, DateTime.Now.AddDays(5), "desc", ETransactionType.Credit, 100M, 100M));
            _transactions.Add(new Transaction(_account1.Id, DateTime.Now.AddDays(5), "desc", ETransactionType.Debit, 100M, 100M));
            _transactions.Add(new Transaction(_account2.Id, "desc", ETransactionType.Credit, 100M, 100M));
            _transactions.Add(new Transaction(_account2.Id, "desc", ETransactionType.Debit, 100M, 100M));
        }

        [Fact]
        public void WhenAAccountIdAndAPeriodAndATypeOfTansactionShouldReturnCorrectTransactions()
        {
            //When
            var transactions = _transactions.AsQueryable().Where(
                TransactionQueries.GetTransactions(DateTime.Now.Date, DateTime.Now.AddDays(1).Date, ETransactionType.Credit, _account1.Id));

            //Then
            Assert.Equal(1, transactions.Count());
        }
    }
}