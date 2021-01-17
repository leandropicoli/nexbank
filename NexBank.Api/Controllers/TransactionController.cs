using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Handlers;
using NexBank.Domain.Repositories;

namespace NexBank.Api.Controllers
{
    [ApiController]
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionHandler _transactionHandler;

        public TransactionController(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            TransactionHandler transactionHandler)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _transactionHandler = transactionHandler;
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CreateTransaction(CreateTransactionCommand command)
        {
            return (GenericCommandResult)_transactionHandler.Handle(command);
        }

        [Route("getTransactions")]
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions(
            DateTime dateFrom,
            DateTime dateTo,
            ETransactionType transactionType,
            Guid accountId)
        {
            return _transactionRepository.GetTransactions(dateFrom, dateTo, transactionType, accountId);
        }
    }
}