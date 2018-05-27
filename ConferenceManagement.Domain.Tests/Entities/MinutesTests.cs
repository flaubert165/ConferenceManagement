
using ConferenceManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class MinutesTests
    {
        [TestMethod]
        public void ToMinutes_Test()
        {
            Minute minute = new Minute();

            int expected = 10;

            Assert.AreEqual(expected, minute.ToMinutes(10));
        }

        [TestMethod]
        public void ToString_Test()
        {
            Minute minute = new Minute();

            string expected = "10min";

            Assert.AreEqual(expected, minute.ToString(10));
        }   
    }
}
