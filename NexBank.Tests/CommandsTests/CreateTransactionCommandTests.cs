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
            var command = new CreditTransactionCommand(
                Guid.NewGuid(),
                "description",
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
            var command = new CreditTransactionCommand(
                Guid.Empty,
                "",
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