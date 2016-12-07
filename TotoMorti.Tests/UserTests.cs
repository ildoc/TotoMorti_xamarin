using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotoMorti.Classes;
using TotoMorti.Extensions;

namespace TotoMorti.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_can_create_group()
        {
            string groupName = "Gruppo di test";
            User u = new User();
           // GroupManager groupManager = new GroupManager();

            var newGroup = u.CreateNewGroup(groupName);
            var storedGroup = groupManager.FindGroupByName(groupName);
            Assert.IsNotNull(storedGroup);
        }
    }
}
