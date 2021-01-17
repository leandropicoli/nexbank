using System;
using Flunt.Notifications;
using Flunt.Validations;
using NexBank.Domain.Commands.Contracts;
using NexBank.Domain.Enums;

namespace NexBank.Domain.Commands.TransactionCommands
{
    public class CreateTransactionCommand : Notifiable, ICommand
    {
        public CreateTransactionCommand(
            Guid accountId,
            string description,
            ETransactionType transactionType,
            decimal value)
        {
            AccountId = accountId;
            Description = description;
            TransactionType = transactionType;
            Value = value;
        }

        public CreateTransactionCommand()
        {

        }

        public Guid AccountId { get; set; }
        public string Description { get; set; }
        public ETransactionType TransactionType { get; set; }
        public decimal Value { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotEmpty(AccountId, "AccountId", "Forneça uma accountId")
                    .IsNotNullOrWhiteSpace(Description, "Description", "A descrição não pode ser vazia")
                    .IsGreaterThan(Value, 0, "Value", "O valor deve ser maior que 0"));
        }
    }
}