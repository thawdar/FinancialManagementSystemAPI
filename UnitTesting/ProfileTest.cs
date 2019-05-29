using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using m = Model;
using d = DataAccess;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class ProfileTest
    {
        readonly m.Profile profile = new m.Profile
        {
            ProfileId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            DisplayName = "Test Name",
            LoginId = "user@gmail.com",
            Pwd = "Pwd",
            Active = true
        };

        [TestMethod]
        public void Insert()
        {
            try
            {
                d.Profile.Insert(profile).Wait();

                Assert.IsTrue(true);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Update()
        {
            try
            {
                d.Profile.Update(profile).Wait();
                
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
                m.Profile obj = d.Profile.Get(profile.ProfileId).Result;
                IEnumerable<m.Profile> profiles = d.Profile.Get().Result;

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
                d.Profile.Delete(profile.ProfileId).Wait();

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
