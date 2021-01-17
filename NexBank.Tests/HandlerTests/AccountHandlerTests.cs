using NexBank.Domain.Commands;
using NexBank.Domain.Commands.AccountCommands;
using NexBank.Domain.Handlers;
using NexBank.Domain.Repositories;
using NexBank.Tests.Repositories;
using Xunit;

namespace NexBank.Tests.HandlerTests
{
    public class AccountHandlerTests
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountHandler _accountHandler;

        public AccountHandlerTests()
        {
            _accountRepository = new FakeAccountRepository();
            _accountHandler = new AccountHandler(_accountRepository);
        }

        [Fact]
        public void GivenAnInvalidCommandShouldNotCreateAccount()
        {
            //Given
            var command = new CreateAccountCommand("", "");

            //When
            var result = (GenericCommandResult)_accountHandler.Handle(command);

            //Then
            Assert.False(result.Success);
        }

        [Fact]
        public void GivenAValidCommandShouldCreateAccount()
        {
            //Given
            var command = new CreateAccountCommand("leandro", "12345");

            //When
            var result = (GenericCommandResult)_accountHandler.Handle(command);

            //Then
            Assert.True(result.Success);
        }

        [Fact]
        public void GivenAnCommandWithoutNameShouldNotCreateAccount()
        {
            //Given
            var command = new CreateAccountCommand("", "123123");

            //When
            var result = (GenericCommandResult)_accountHandler.Handle(command);

            //Then
            Assert.False(result.Success);
        }

        [Fact]
        public void GivenAnCommandWithoutDocumentShouldNotCreateAccount()
        {
            //Given
            var command = new CreateAccountCommand("leandro", "");

            //When
            var result = (GenericCommandResult)_accountHandler.Handle(command);

            //Then
            Assert.False(result.Success);
        }
    }
}