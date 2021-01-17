using System;
using System.Collections.Generic;

namespace NexBank.Domain.Models
{
    public class TransactionsListDTO
    {
        public TransactionsListDTO()
        {
        }
        public TransactionsListDTO(Guid accountId, decimal initialAccountBalance, decimal finishAccountBalance)
        {
            AccountId = accountId;
            InitialAccountBalance = initialAccountBalance;
            FinishAccountBalance = finishAccountBalance;
            Transactions = new List<TransactionDTO>();
        }
        public Guid AccountId { get; set; }
        public decimal InitialAccountBalance { get; set; }
        public decimal FinishAccountBalance { get; set; }
        public List<TransactionDTO> Transactions { get; set; }
    }
}