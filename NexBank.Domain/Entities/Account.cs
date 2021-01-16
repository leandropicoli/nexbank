using System;

namespace NexBank.Domain.Entities
{
    public class Account : Entity
    {
        public Account(string name, string document)
        {
            CreateDate = DateTime.Now;
            Name = name;
            Document = document;
            Balance = 0M;
        }

        public DateTime CreateDate { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public decimal Balance { get; private set; }

        public void UpdateBalance(decimal newBalance)
        {
            Balance = newBalance;
        }

    }
}