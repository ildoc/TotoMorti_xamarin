using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TotoMorti.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MustPass()
        {
            int expected = 1;
            int actual = 1;
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void NewCurrentUserTotoListHasDefaultCategory()
        //{
        //    User CurrentUser =
        //    TotoList totoList = App.CurrentUser.CreateTotoList();
        //    Assert.AreEqual("Default Category", totoList.Categories[0]);
        //}
    }
}
