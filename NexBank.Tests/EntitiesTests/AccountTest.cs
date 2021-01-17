using NexBank.Domain.Entities;
using Xunit;

namespace NexBank.Tests.EntitiesTests
{
    public class AccountTest
    {
        private readonly Account _account;

        public AccountTest()
        {
            _account = new Account("leandro", "1234", 100M);
        }

        [Fact]
        public void ShouldUpdateBalanceWhenUpdateBalanceIsCalled()
        {
            //When
            _account.UpdateBalance(250M);

            //Then
            Assert.Equal(250M, _account.Balance);
        }

        [Fact]
        public void ShouldDecreaseTheValueWhenDebitIsCalled()
        {
            //When
            _account.Debit(50M);

            //Then
            Assert.Equal(50M, _account.Balance);
        }

        [Fact]
        public void ShouldIncreaseTheValueWhenCreditIsCalled()
        {
            //When
            _account.Credit(50M);

            //Then
            Assert.Equal(150M, _account.Balance);
        }
    }
}