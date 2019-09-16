using System;
using Model.Attributes;

namespace Model
{
    public class Account
    {
        [PrimaryKey]
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public Guid ProfileId { get; set; }
    }

    public class AccountWithBalance : Account
    {
        public decimal Balance { get; set; }
    }

}
