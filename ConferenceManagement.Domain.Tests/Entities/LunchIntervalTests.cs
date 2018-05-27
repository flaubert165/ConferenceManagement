using System;
using ConferenceManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class LunchIntervalTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ScheduledLunch_OnBadTime_Test()
        {
            DateTime dateTime = DateTime.Parse("11:00:00 PM");
            Lunch lunch = new Lunch();
            LunchInterval lunchIntervall = new LunchInterval(lunch, dateTime);
        }
    }
}
