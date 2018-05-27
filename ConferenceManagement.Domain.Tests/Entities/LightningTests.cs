using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class LightningTests
    {
        [TestMethod]
        public void ToMinutes_Test()
        {
            Lightning lightning = new Lightning();

            int expected = 10 * AppSettings.LightningSessionDuration;

            Assert.AreEqual(expected, lightning.ToMinutes(10));
        }

        [TestMethod]
        public void ToString_Test()
        {
            Lightning lightning = new Lightning();

            string expected = "lightning";

            Assert.AreEqual(expected, lightning.ToString(10));
        }
    }
}
