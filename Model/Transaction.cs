using System;
using Model.Attributes;

namespace Model
{
    public class Transaction
    {
        [PrimaryKey]
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Particular { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

        public Category Category { get; set; }
        public Account Account { get; set; }
    }
}
