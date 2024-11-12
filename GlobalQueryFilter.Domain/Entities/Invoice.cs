using System;

namespace GlobalQueryFilter.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public string Owner { get; private set; }
        public decimal Value { get; private set; }

        protected Invoice() { }

        public Invoice(string owner, decimal value)
        {
            Id = Guid.NewGuid();
            Owner = owner;
            Value = value;
        }
    }
}
