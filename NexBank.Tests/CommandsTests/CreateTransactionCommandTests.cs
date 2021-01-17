using System;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Enums;
using Xunit;

namespace NexBank.Tests.CommandsTests
{
    public class CreateTransactionCommandTests
    {
        [Fact]
        public void WhenAValidCommandIsGivenShouldBeValid()
        {
            //Given
            var command = new CreateTransactionCommand(
                Guid.NewGuid(),
                "description",
                ETransactionType.Credit,
                100M
            );

            //When
            command.Validate();

            //Then
            Assert.True(command.Valid);
        }

        [Fact]
        public void WhenAnInvalidcommandIsGivenShouldNotBeValid()
        {
            //Given
            var command = new CreateTransactionCommand(
                Guid.Empty,
                "",
                ETransactionType.Credit,
                0M
            );

            //When
            command.Validate();

            //Then
            Assert.True(command.Invalid);
            Assert.Equal(3, command.Notifications.Count);
        }
    }
}