using System;

namespace NexBank.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}