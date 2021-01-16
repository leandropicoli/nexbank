using NexBank.Domain.Commands.Contracts;

namespace NexBank.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}