using System;
using NexBank.Domain.Commands.Contracts;

namespace NexBank.Domain.Commands.TransactionCommands
{
    public class CreditTransactionCommand : TransactionCommand
    {
        public CreditTransactionCommand()
        {

        }
        public CreditTransactionCommand(Guid accountId, string description, decimal value)
        {
            AccountId = accountId;
            Description = description;
            Value = value;
        }
    }
}