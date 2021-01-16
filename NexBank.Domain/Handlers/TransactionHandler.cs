using Flunt.Notifications;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.Contracts;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Handlers.Contracts;
using NexBank.Domain.Repositories;

namespace NexBank.Domain.Handlers
{
    public class TransactionHandler : Notifiable, IHandler<CreateTransactionCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public ICommandResult Handle(CreateTransactionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao lançar transação", command.Notifications);

            var account = _accountRepository.GetById(command.AccountId);

            //TODO: Criar uma forma melhor de processar os pgtos
            if (command.TransactionType == Enums.ETransactionType.Credit)
            {
                account.Credit(command.Value);
            }
            else if (command.TransactionType == Enums.ETransactionType.Debit)
            {
                if (account.Balance < command.Value)
                    return new GenericCommandResult(false, "Saldo insuficiente", "Não há salda suficiente para realizar a operaçao");

                account.Debit(command.Value);
            };

            Transaction transaction;

            if (command.CreateDateTime.HasValue)
            {
                transaction = new Transaction(account.Id, command.CreateDateTime.Value, command.Description, command.TransactionType, command.Value, account.Balance);
            }
            else
            {
                transaction = new Transaction(account.Id, command.Description, command.TransactionType, command.Value, account.Balance);
            }

            _transactionRepository.SaveTransaction(transaction);
            _accountRepository.SaveAccount(account);

            return new GenericCommandResult(true, "Transaçao realizada com sucesso", transaction);
        }
    }
}