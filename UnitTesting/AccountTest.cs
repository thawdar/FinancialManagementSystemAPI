using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using m = Model;
using d = DataAccess;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class AccountTest
    {
        readonly m.Account account = new m.Account
        {
            AccountId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            AccountName = "Test Name",
            AccountType = "Expense",
            OpeningDate = DateTime.Now,
            OpeningBalance = 0,
            ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000000")
        };

        //[TestInitialize]
        //public void Initialize()
        //{
        //    m.Profile profile = new m.Profile
        //    {
        //        ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        //        DisplayName = "Test Name",
        //        LoginId = "user@gmail.com",
        //        Pwd = "Pwd",
        //        Active = true
        //    };

        //    d.Profile.Insert(profile).Wait();
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    d.Profile.Delete(Guid.Parse("00000000-0000-0000-0000-000000000000")).Wait();
        //}

        [TestMethod]
        public void Insert()
        {
            try
            {
                d.Account.Insert(account).Wait();

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Update()
        {
            try
            {
                d.Account.Update(account).Wait();

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Get()
        {
            try
            {
                m.Account obj = d.Account.Get(account.ProfileId).Result;
                IEnumerable<m.Account> accounts = d.Account.Get().Result;

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Delete()
        {
            try
            {
                d.Account.Delete(account.AccountId).Wait();

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
