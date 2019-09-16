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

    public class Period
    {
        private DateTime _start, _end;
        
        public DateTime StartDate
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value; //new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _end;
            }
            set
            {
                _end = new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
            }
        }
    }

    public class TransactionFilter : Period
    {
        public Guid ProfileId { get; set; }
    }

    public class CashBookFilter : Period
    {
        public Guid AccountId { get; set; }
    }
}