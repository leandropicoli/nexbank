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
        private readonly IUnitOfWork _uow;
        public AccountHandler(IAccountRepository accountRepository, IUnitOfWork uow)
        {
            _accountRepository = accountRepository;
            _uow = uow;
        }

        public ICommandResult Handle(CreateAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao cadastrar nova conta", command.Notifications);

            var account = new Account(command.Name, command.Document);
            _accountRepository.AddAccount(account);
            _uow.Commit();

            return new GenericCommandResult(true, "Conta criada com sucesso", account);
        }
    }
}