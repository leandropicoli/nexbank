using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Repositories;
using NexBank.Domain.Services;
using NSubstitute;
using Xunit;

namespace NexBank.Tests.ServicesTests
{
    public class TransactionFilterServiceTests
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionsFilterService _transactionFilterService;
        private List<Transaction> _transactions;
        private Account _account;

        public TransactionFilterServiceTests()
        {
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _transactionFilterService = new TransactionsFilterService(_transactionRepository);

            _account = new Account("test", "1214");

            _transactions = new List<Transaction>();
        }

        [Fact]
        public void WhenNoTransactionsIsGivenShouldReturnEmptyObject()
        {
            //Given
            _transactionRepository.GetTransactions(default, default, default, default).Returns(new List<Transaction>());

            //When
            var result = _transactionFilterService.GetAndFilterTransactions(
                            DateTime.Now.Date,
                            DateTime.Now.AddDays(1).Date,
                            ETransactionType.Credit,
                            _account.Id);
            //Then
            Assert.Equal(0, result.InitialAccountBalance);
            Assert.Equal(0, result.FinalAccountBalance);
            Assert.Equal(0, result.Transactions.Count);
        }

        [Fact]
        public void WhenACoupleOfTransactionsIsGivenShouldReturnTheRightAmountOfTransactions()
        {
            //Given
            _transactions.Add(new Transaction(_account.Id, "desc", ETransactionType.Credit, 100M, 100M, 0M));
            _transactions.Add(new Transaction(_account.Id, "desc", ETransactionType.Credit, 50M, 150M, 100M));
            _transactionRepository.GetTransactions(default, default, default, default).ReturnsForAnyArgs(_transactions);

            //When
            var result = _transactionFilterService.GetAndFilterTransactions(
                            DateTime.Now.Date,
                            DateTime.Now.AddDays(1).Date,
                            ETransactionType.Credit,
                            _account.Id);
            //Then
            Assert.Equal(0, result.InitialAccountBalance);
            Assert.Equal(150, result.FinalAccountBalance);
            Assert.Equal(2, result.Transactions.Count);
        }
    }
}