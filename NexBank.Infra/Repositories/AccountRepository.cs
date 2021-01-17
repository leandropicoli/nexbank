using NexBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NexBank.Infra.Contexts;
using NexBank.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NexBank.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts
                .AsNoTracking()
                .ToList();
        }

        public Account GetById(Guid id)
        {
            return _context.Accounts
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public void UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}