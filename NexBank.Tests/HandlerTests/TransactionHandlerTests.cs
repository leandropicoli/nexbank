using System;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Handlers;
using NexBank.Domain.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace NexBank.Tests.HandlerTests
{
    public class TransactionHandlerTests
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionHandler _transactionHandler;

        public TransactionHandlerTests()
        {
            _accountRepository = Substitute.For<IAccountRepository>();
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _transactionHandler = new TransactionHandler(_accountRepository, _transactionRepository);
        }

        [Fact]
        public void GivenAnInvalidCommandShouldNotCreateTransaction()
        {
            //Given
            var command = new CreateTransactionCommand(Guid.NewGuid(), "", ETransactionType.Credit, 0M);

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.False(result.Success);
        }

        [Fact]
        public void GivenAnInnexistentAccountShouldNotCreateTransaction()
        {
            //Given
            var command = new CreateTransactionCommand(
                Guid.NewGuid(),
                "Credito realizado",
                ETransactionType.Credit,
                100M);

            _accountRepository.GetById(command.AccountId)
                .ReturnsNull();

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.False(result.Success);
            Assert.Equal("Conta não localizada", result.Message);
        }

        [Fact]
        public void GivenAValidCommandAndAccountShouldCreateTransaction()
        {
            //Given
            var account = new Account("test", "1234");
            _accountRepository.GetById(account.Id)
                    .Returns(account);

            var command = new CreateTransactionCommand(
                account.Id,
                "Deposit",
                ETransactionType.Credit,
                100M);

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.True(result.Success);
        }

        [Fact]
        public void GivenATransactionWithoutEnoughBalanceShouldNoteCreateTransaction()
        {
            //Given
            var account = new Account("test", "1234");
            _accountRepository.GetById(account.Id)
                    .Returns(account);

            var command = new CreateTransactionCommand(
                account.Id,
                "Compra XPTO",
                ETransactionType.Debit,
                100M);

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.False(result.Success);
            Assert.Equal("Saldo insuficiente", result.Message);
        }
    }
}