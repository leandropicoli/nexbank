using System;
using System.Linq;
using NexBank.Domain.DTOs;
using NexBank.Domain.Enums;
using NexBank.Domain.Repositories;

namespace NexBank.Domain.Services
{
    public class TransactionsFilterService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsFilterService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public TransactionsListDTO GetAndFilterTransactions(
            DateTime dateFrom,
            DateTime dateTo,
            ETransactionType transactionType,
            Guid accountId)
        {
            var transactions = _transactionRepository.GetTransactions(dateFrom, dateTo, transactionType, accountId);
            if (!transactions.Any()) return new TransactionsListDTO();

            var transactionsList = new TransactionsListDTO(
                accountId,
                transactions.First().AccountBalanceBefore,
                transactions.Last().AccountBalanceAfter);

            foreach (var item in transactions)
            {
                transactionsList.Transactions.Add(
                    new TransactionDTO(
                        item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss"),
                        item.Description,
                        item.Value));
            }

            return transactionsList;
        }
    }
}