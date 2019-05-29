using System;
using Model.Attributes;

namespace Model
{
    public class Subscription
    {
        [PrimaryKey]
        public Guid SubscriptionId { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Amount { get; set; }
        public Guid ProfileId { get; set; }
    }
}
