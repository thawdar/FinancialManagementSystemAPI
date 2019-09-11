using System;
using Model.Attributes;

namespace Model
{
    public class DailyTransaction
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

    public class TransactionFilter
    {
        public Guid ProfileId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}


