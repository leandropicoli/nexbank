using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;

namespace NexBank.Domain.Repositories
{
    public interface IAccountRepository
    {
        void SaveAccount(Account account);
        IEnumerable<Account> GetAll();
        Account GetById(Guid id);
    }
}