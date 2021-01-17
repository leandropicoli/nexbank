using Flunt.Notifications;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.Contracts;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
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

            if (account == null)
                return new GenericCommandResult(false, "Conta não localizada", "Não foi possivel localizar a conta");

            //TODO: Criar uma forma melhor de processar os pgtos
            // switch (command.TransactionType)
            // {
            //     case ETransactionType.Credit:
            //         account.Credit(command.Value);
            //         break;
            //     case ETransactionType.Debit:
            //         account.Debit(command.Value);
            //         break;
            //     default:
            //         return new GenericCommandResult(false, "Transação não permitida", "Não foi possivel identificar o tipo de transação");
            // }
            var accountBalanceBefore = account.Balance;

            if (command.TransactionType == ETransactionType.Credit)
            {
                account.Credit(command.Value);
            }
            else if (command.TransactionType == ETransactionType.Debit)
            {
                if (account.Balance < command.Value)
                    return new GenericCommandResult(false, "Saldo insuficiente", "Não há salda suficiente para realizar a operaçao");

                account.Debit(command.Value);
            };

            Transaction transaction;

            if (command.CreateDateTime.HasValue)
            {
                transaction = new Transaction(account.Id, command.CreateDateTime.Value, command.Description, command.TransactionType, command.Value, account.Balance, accountBalanceBefore);
            }
            else
            {
                transaction = new Transaction(account.Id, command.Description, command.TransactionType, command.Value, account.Balance, accountBalanceBefore);
            }

            _transactionRepository.SaveTransaction(transaction);
            _accountRepository.UpdateAccount(account);

            return new GenericCommandResult(true, "Transaçao realizada com sucesso", transaction);
        }
    }
}