using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotoMorti.Classes;
using TotoMorti.Extensions;
using TotoMorti.Interfaces;
using TotoMorti.Managers;

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
            var testDb = new TestSqliteDb();

            GroupManager groupManager = new GroupManager(testDb);

            var newGroup = u.CreateNewGroup();
            newGroup.Title = groupName;
            groupManager.AddGroup(newGroup);
            var storedGroup = groupManager.FindGroupByName(groupName);
            Assert.IsNotNull(storedGroup);
        }
    }
}
