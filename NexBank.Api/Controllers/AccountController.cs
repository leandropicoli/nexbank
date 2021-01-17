using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NexBank.Domain.Commands;
using NexBank.Domain.Commands.AccountCommands;
using NexBank.Domain.Entities;
using NexBank.Domain.Handlers;
using NexBank.Domain.Repositories;

namespace NexBank.Api.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountHandler _handler;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _uow;

        public AccountController(AccountHandler handler, IAccountRepository accountRepository, IUnitOfWork uow)
        {
            _handler = handler;
            _accountRepository = accountRepository;
            _uow = uow;
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CreateAccount(CreateAccountCommand createAccountCommand)
        {
            return (GenericCommandResult)_handler.Handle(createAccountCommand);
        }

        [Route("getAll")]
        [HttpGet]
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAll();
        }

        [Route("getById")]
        [HttpGet]
        public Account GetById(Guid id)
        {
            return _accountRepository.GetById(id);
        }

    }
}