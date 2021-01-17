using NexBank.Domain.Handlers;
using NexBank.Domain.Repositories;
using NexBank.Tests.Repositories;
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
            _accountRepository = new FakeAccountRepository();
            _transactionRepository = new FakeTransactionRepository();
            _transactionHandler = new TransactionHandler(_accountRepository, _transactionRepository);
        }

        [Fact]
        public void TestName()
        {
            //Given

            //When

            //Then
        }
    }
}