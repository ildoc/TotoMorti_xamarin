using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TotoMorti.Classes;
using TotoMorti.Extensions;

namespace TotoMorti.Tests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void Group_can_have_only_one_active_session()
        {
            var newGroup = new Group();
            newGroup.CreateNewSession();
            newGroup.CreateNewSession();
            newGroup.CreateNewSession();

            Assert.IsTrue(newGroup.Sessions.Count(x => x.IsActive) == 1);
        }
    }
}