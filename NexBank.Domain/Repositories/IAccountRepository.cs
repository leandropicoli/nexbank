using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;

namespace NexBank.Domain.Repositories
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        IEnumerable<Account> GetAll();
        Account GetById(Guid id);
    }
}