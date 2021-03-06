using System;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
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
        private readonly IUnitOfWork _uow;

        public TransactionHandlerTests()
        {
            _accountRepository = Substitute.For<IAccountRepository>();
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _uow = Substitute.For<IUnitOfWork>();
            _transactionHandler = new TransactionHandler(_accountRepository, _transactionRepository, _uow);
        }

        [Fact]
        public void GivenAnInvalidCommandShouldNotCreateTransaction()
        {
            //Given
            var command = new CreditTransactionCommand(Guid.NewGuid(), "", 0M);

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.False(result.Success);
        }

        [Fact]
        public void GivenAnInnexistentAccountShouldNotCreateTransaction()
        {
            //Given
            var command = new CreditTransactionCommand(
                Guid.NewGuid(),
                "Credito realizado",
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

            var command = new CreditTransactionCommand(
                account.Id,
                "Deposit",
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

            var command = new DebitTransactionCommand(
                account.Id,
                "Compra XPTO",
                100M);

            //When
            var result = (GenericCommandResult)_transactionHandler.Handle(command);

            //Then
            Assert.False(result.Success);
            Assert.Equal("Saldo insuficiente", result.Message);
        }
    }
}