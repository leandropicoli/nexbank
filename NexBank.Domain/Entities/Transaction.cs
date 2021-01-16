using System;
using NexBank.Domain.Enums;

namespace NexBank.Domain.Entities
{
    public class Transaction : Entity
    {
        public Transaction(Guid accountId, string description, ETransactionType transactionType, decimal value, decimal accountBalanceAfter)
        {
            AccountId = accountId;
            CreateDate = DateTime.Now;
            Description = description;
            TransactionType = transactionType;
            Value = value;
            AccountBalanceAfter = accountBalanceAfter;
        }

        public Transaction(Guid accountId, DateTime createDate, string description, ETransactionType transactionType, decimal value, decimal accountBalanceAfter)
        {
            AccountId = accountId;
            CreateDate = createDate;
            Description = description;
            TransactionType = transactionType;
            Value = value;
            AccountBalanceAfter = accountBalanceAfter;
        }

        public Guid AccountId { get; private set; }
        public virtual Account Account { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Description { get; private set; }
        public ETransactionType TransactionType { get; private set; }
        public decimal Value { get; private set; }
        public decimal AccountBalanceAfter { get; private set; }
    }
}