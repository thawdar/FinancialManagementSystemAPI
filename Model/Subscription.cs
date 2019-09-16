using System;
using Model.Attributes;

namespace Model
{
    public class Subscription
    {
        [PrimaryKey]
        public Guid SubscriptionId { get; set; }

        private DateTime _SubscriptionDateDate;
        public DateTime SubscriptionDateDate
        {
            get => _SubscriptionDateDate;
            set => _SubscriptionDateDate = Shared.GetLocalDateTime(value);
        }

        private DateTime _ValidUntil;
        public DateTime ValidUntil
        {
            get => _SubscriptionDateDate;
            set => _ValidUntil = Shared.GetLocalDateTime(value);
        }
        public decimal Amount { get; set; }
        public Guid ProfileId { get; set; }
    }
}
