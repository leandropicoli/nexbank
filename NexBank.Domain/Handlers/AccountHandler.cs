using Flunt.Notifications;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.AccountCommands;
using NexBank.Domain.Commands.Contracts;
using NexBank.Domain.Entities;
using NexBank.Domain.Handlers.Contracts;
using NexBank.Domain.Repositories;

namespace NexBank.Domain.Handlers
{
    public class AccountHandler : Notifiable, IHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ICommandResult Handle(CreateAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao cadastrar nova conta", command.Notifications);

            var account = new Account(command.Name, command.Document);
            _accountRepository.AddAccount(account);

            return new GenericCommandResult(true, "Conta criada com sucesso", account);
        }
    }
}