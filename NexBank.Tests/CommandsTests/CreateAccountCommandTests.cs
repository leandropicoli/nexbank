using NexBank.Domain.Commands.AccountCommands;
using Xunit;

namespace NexBank.Tests.CommandsTests
{
    public class CreateAccountCommandTests
    {
        [Fact]
        public void WhenAValidCommandIsGivenShouldBeValid()
        {
            //Given
            var command = new CreateAccountCommand("test", "1234");

            //When
            command.Validate();

            //Then
            Assert.True(command.Valid);
        }

        [Fact]
        public void WhenAnInvalidCommandIsGivenShouldBeInvalid()
        {
            //Given
            var command = new CreateAccountCommand("", "");

            //When
            command.Validate();

            //Then
            Assert.True(command.Invalid);
        }
    }
}