using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Infra;
using ConferenceManagement.Services.BinPackingLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Services.Tests.BinPackingLogic
{
    [TestClass]
    public class ConferencePlanningTests
    {
        private Conference conference;
        private ConferencePlanningService scheduler = new ConferencePlanningService();
        private List<Talk> events;
        private List<ScheduledTalk> scheduledEvents;

        [TestInitialize]
        public void SetUp()
        {
            var file = "/Users/italosantana/Desktop/ConferenceManagement/ConferenceManagement.Services.Tests/InputData/TestInput.txt";

            events = new List<Talk>(new TalkRepository().GetTalksFromTextFile(file));
            conference = scheduler.GreedyBestFitApproach(events);
            scheduledEvents = new List<ScheduledTalk>();

            foreach (Tracker track in conference)
            {
                scheduledEvents.AddRange(track);
            }
        }

        [TestMethod]
        public void CheckIfAllEventsAreScheduled_Test()
        {
            foreach (Talk conferenceEvent in events)
            {
                Assert.IsTrue(scheduledEvents.Any(e => e.IsScheduledFor(conferenceEvent)));
            }
        }

        [TestMethod]
        public void CheckIfLunchesAreScheduled_Test()
        {
            int expectedNumberOfLunches = 1;
            foreach (Tracker track in conference)
            {
                Assert.AreEqual(expectedNumberOfLunches, track.Count(e => e is LunchInterval));
            }
        }

        [TestMethod]
        public void CheckIfNetworkEventsAreScheduled_Test()
        {
            int expectedNumberOfNetworkingEvents = 1;
            foreach (Tracker track in conference)
            {
                Assert.AreEqual(expectedNumberOfNetworkingEvents, track.Count(e => e is ScheduledNetworkingEvent));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlanConferenceWithUnplannableEent_Test()
        {
            Talk veryLongEvent = new Talk(string.Empty, new Duration(300, new Minute()));
            events.Add(veryLongEvent);
            conference = scheduler.GreedyBestFitApproach(events);
        }
    }
}
