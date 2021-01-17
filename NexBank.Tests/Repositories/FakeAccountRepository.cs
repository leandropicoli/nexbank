using System;
using System.Collections.Generic;
using NexBank.Domain.Entities;
using NexBank.Domain.Repositories;

namespace NexBank.Tests.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public void AddAccount(Account account)
        {

        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {

        }
    }
}