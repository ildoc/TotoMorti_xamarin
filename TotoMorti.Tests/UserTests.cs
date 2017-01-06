using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotoMorti.Extensions;
using TotoMorti.Models;

namespace TotoMorti.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_is_in_a_created_group()
        {
            var u = new User();

            var newGroup = u.CreateNewGroup();
            Assert.IsNotNull(newGroup.Users.Contains(u));
        }

        [TestMethod]
        public void User_is_owner_of_a_created_group()
        {
            var u = new User();

            var newGroup = u.CreateNewGroup();
            Assert.IsNotNull(newGroup.GroupOwner == u);
        }
    }
}