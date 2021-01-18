using System;
using System.Collections.Generic;

namespace NexBank.Domain.DTOs
{
    public class TransactionsListDTO
    {
        public TransactionsListDTO()
        {
            Transactions = new List<TransactionDTO>();
        }
        public TransactionsListDTO(Guid accountId, decimal initialAccountBalance, decimal finishAccountBalance)
        {
            AccountId = accountId;
            InitialAccountBalance = initialAccountBalance;
            FinalAccountBalance = finishAccountBalance;
            Transactions = new List<TransactionDTO>();
        }
        public Guid AccountId { get; set; }
        public decimal InitialAccountBalance { get; set; }
        public decimal FinalAccountBalance { get; set; }
        public List<TransactionDTO> Transactions { get; set; }
    }
}