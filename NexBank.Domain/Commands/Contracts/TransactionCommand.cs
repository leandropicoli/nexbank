using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace NexBank.Domain.Commands.Contracts
{
    public abstract class TransactionCommand : Notifiable, ICommand
    {
        public Guid AccountId { get; set; }
        public string Description { get; set; }
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