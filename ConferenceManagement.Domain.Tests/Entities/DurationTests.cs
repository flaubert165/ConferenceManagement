using ConferenceManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class DurationTests
    {
        [TestMethod]
        public void GetValueInMinutes_MinuteUnit_Test()
        {
            Duration duration = new Duration(10, new Minute());

            int expected = 10;

            Assert.AreEqual(expected, duration.GetValueInMinutes());
        }

        [TestMethod]
        public void GetValueInMinutes_LightningUnit_Test()
        {
            Duration duration = new Duration(new Lightning());

            int expected = 5;

            Assert.AreEqual(expected, duration.GetValueInMinutes());
        }

        [TestMethod]
        public void ToString_MinuteUnit_Test()
        {
            Duration duration = new Duration(10, new Minute());

            string expected = "10min";

            Assert.AreEqual(expected, duration.ToString());
        }

        [TestMethod]
        public void ToString_LightningUnit_Test()
        {
            Duration duration = new Duration(new Lightning());

            string expected = "lightning";

            Assert.AreEqual(expected, duration.ToString());
        }
    }
}
