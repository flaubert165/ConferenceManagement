using System;
using ConferenceManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class ScheduledNetworkingEventTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestScheduledNetworkEvent_StartTimeEarlierThanMin()
        {
            DateTime start = DateTime.Parse("03:59:00 PM");
            ScheduledNetworkingEvent networkEvent = new ScheduledNetworkingEvent(new NetworkingEvent(), start);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestScheduledNetworkEvent_StartTimeAfterThanMax()
        {
            DateTime start = DateTime.Parse("05:01:00 PM");
            ScheduledNetworkingEvent networkEvent = new ScheduledNetworkingEvent(new NetworkingEvent(), start);
        }
    }
}
