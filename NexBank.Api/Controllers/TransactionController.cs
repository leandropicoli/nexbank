using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.TransactionCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Enums;
using NexBank.Domain.Handlers;
using NexBank.Domain.Models;
using NexBank.Domain.Repositories;
using NexBank.Domain.Services;

namespace NexBank.Api.Controllers
{
    [ApiController]
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly TransactionHandler _transactionHandler;
        private readonly IUnitOfWork _uow;

        public TransactionController(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            TransactionHandler transactionHandler,
            IUnitOfWork uow)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _transactionHandler = transactionHandler;
            _uow = uow;
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CreateTransaction(CreateTransactionCommand command)
        {
            return (GenericCommandResult)_transactionHandler.Handle(command);
        }

        [Route("getTransactions")]
        [HttpGet]
        public TransactionsListDTO GetTransactions(
            DateTime dateFrom,
            DateTime dateTo,
            ETransactionType transactionType,
            Guid accountId)
        {
            var transactionService = new TransactionsFilterService(_transactionRepository);
            return transactionService.GetAndFilterTransactions(dateFrom, dateTo, transactionType, accountId);
        }
    }
}