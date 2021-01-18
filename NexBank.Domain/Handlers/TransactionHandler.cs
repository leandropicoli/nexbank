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
    public class TransactionHandler :
                Notifiable,
                IHandler<CreditTransactionCommand>,
                IHandler<DebitTransactionCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _uow;

        public TransactionHandler(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            IUnitOfWork uow)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _uow = uow;
        }

        public ICommandResult Handle(CreditTransactionCommand command)
        {
            var account = _accountRepository.GetById(command.AccountId);

            var validate = ValidateCommand(command, account);
            if (validate != null) return validate;

            var accountBalanceBefore = account.Balance;

            account.Credit(command.Value);

            var transaction = new Transaction(account.Id, command.Description, ETransactionType.Credit, command.Value, account.Balance, accountBalanceBefore);

            _transactionRepository.SaveTransaction(transaction);
            _accountRepository.UpdateAccount(account);
            _uow.Commit();

            return new GenericCommandResult(true, "Transaçao realizada com sucesso", transaction);
        }

        public ICommandResult Handle(DebitTransactionCommand command)
        {
            var account = _accountRepository.GetById(command.AccountId);

            var validate = ValidateCommand(command, account);
            if (validate != null) return validate;

            var accountBalanceBefore = account.Balance;

            if (account.Balance < command.Value)
                return new GenericCommandResult(false, "Saldo insuficiente", "Não há salda suficiente para realizar a operaçao");

            account.Debit(command.Value);

            var transaction = new Transaction(account.Id, command.Description, ETransactionType.Debit, command.Value, account.Balance, accountBalanceBefore);

            _transactionRepository.SaveTransaction(transaction);
            _accountRepository.UpdateAccount(account);
            _uow.Commit();

            return new GenericCommandResult(true, "Transaçao realizada com sucesso", transaction);
        }

        private GenericCommandResult ValidateCommand(TransactionCommand command, Account account)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro ao lançar transação", command.Notifications);

            if (account == null)
                return new GenericCommandResult(false, "Conta não localizada", "Não foi possivel localizar a conta");

            return null;
        }

    }
}