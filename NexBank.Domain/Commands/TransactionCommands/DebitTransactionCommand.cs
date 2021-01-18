using System;
using NexBank.Domain.Commands.Contracts;

namespace NexBank.Domain.Commands.TransactionCommands
{
    public class DebitTransactionCommand : TransactionCommand
    {
        public DebitTransactionCommand()
        {

        }
        public DebitTransactionCommand(Guid accountId, string description, decimal value)
        {
            AccountId = accountId;
            Description = description;
            Value = value;
        }
    }
}