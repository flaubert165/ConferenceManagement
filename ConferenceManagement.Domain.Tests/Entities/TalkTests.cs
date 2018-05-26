using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class TalkTests
    {
        [TestMethod]
        public void DurationInMinutes_UnitMinutes_Test()
        {
            Duration duration = new Duration(30, new Minute());
            Talk talk = new Talk(string.Empty, duration);

            int expected = 30;

            Assert.AreEqual(expected, talk.DurationInMinutes());
        }

        [TestMethod]
        public void DurationInMinutes_TimeUnitLightning_Test()
        {
            Duration duration = new Duration(new Lightning());

            Talk talk = new Talk(string.Empty, duration);

            int expected = AppSettings.LightningSessionDuration;

            Assert.AreEqual(expected, talk.DurationInMinutes());
        }

        [TestMethod]
        public void TestToString_UnitMinute_Test()
        {
            Duration duration = new Duration(30, new Minute());

            Talk talk = new Talk("event", duration);

            string expected = "event 30min";

            Assert.AreEqual(expected, talk.ToString());
        }

        [TestMethod]
        public void ToString_UnitLightningTest()
        {
            Duration duration = new Duration(new Lightning());

            Talk talk = new Talk("event", duration);

            string expected = "event lightning";

            Assert.AreEqual(expected, talk.ToString());
        }

        [TestMethod]
        public void CompareTo_MinutesToMinutes_Test()
        {
            Duration shorter = new Duration(10, new Minute());
            Duration longer = new Duration(20, new Minute());

            Talk shorterEvent = new Talk(string.Empty, shorter);
            Talk longerEvent = new Talk(string.Empty, longer);

            Assert.IsTrue(shorterEvent.CompareTo(longerEvent) > 0);
            Assert.IsTrue(longerEvent.CompareTo(shorterEvent) < 0);
            Assert.IsTrue(shorterEvent.CompareTo(shorterEvent) == 0);
            Assert.IsTrue(longerEvent.CompareTo(longerEvent) == 0);
        }

        [TestMethod]
        public void CompareTo_MinutesToLightning_Test()
        {
            Duration oneMinute = new Duration(1, new Minute());
            Duration fiveMinutes = new Duration(5, new Minute());
            Duration tenMinutes = new Duration(10, new Minute());
            Duration lightning = new Duration(new Lightning());
            Talk oneMinuteEvent = new Talk(string.Empty, oneMinute);
            Talk fiveMinuteEvent = new Talk(string.Empty, fiveMinutes);
            Talk tenMinutesEvent = new Talk(string.Empty, tenMinutes);
            Talk lightningEvent = new Talk(string.Empty, lightning);


            Assert.IsTrue(fiveMinuteEvent.CompareTo(lightningEvent) == 0);
            Assert.IsTrue(oneMinuteEvent.CompareTo(lightningEvent) > 0);
            Assert.IsTrue(tenMinutesEvent.CompareTo(lightningEvent) < 0);

            Assert.IsTrue(lightningEvent.CompareTo(fiveMinuteEvent) == 0);
            Assert.IsTrue(lightningEvent.CompareTo(tenMinutesEvent) > 0);
            Assert.IsTrue(lightningEvent.CompareTo(oneMinuteEvent) < 0);
        }

        [TestMethod]
        public void CompareTo_LightningToLightning_Test()
        {
            Duration lightning = new Duration(new Lightning());
            Talk lightningEvent = new Talk(string.Empty, lightning);

            Assert.IsTrue(lightningEvent.CompareTo(lightningEvent) == 0);
        }
    }
}
