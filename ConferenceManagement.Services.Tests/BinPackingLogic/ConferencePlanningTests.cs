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
        private ConferencePlannerService planner = new ConferencePlannerService();
        private List<Talk> talks;
        private List<ScheduledTalk> scheduledTalks;

        [TestInitialize]
        public void SetUp()
        {
            var file = "/Users/italosantana/Desktop/ConferenceManagement/ConferenceManagement.Services.Tests/InputData/TestInput.txt";

            talks = new List<Talk>(new TalkRepository().GetTalksFromTextFile(file));
            conference = planner.GreedyBestFitApproach(talks);
            scheduledTalks = new List<ScheduledTalk>();

            foreach (Tracker track in conference)
            {
                scheduledTalks.AddRange(track);
            }
        }

        [TestMethod]
        public void CheckIfAllTalksAreScheduled_Test()
        {
            foreach (Talk talk in talks)
            {
                Assert.IsTrue(scheduledTalks.Any(e => e.IsScheduledFor(talk)));
            }
        }

        [TestMethod]
        public void CheckIfLunchesAreScheduled_Test()
        {
            int expectedLunches = 1;
            foreach (Tracker track in conference)
            {
                Assert.AreEqual(expectedLunches, track.Count(e => e is LunchInterval));
            }
        }

        [TestMethod]
        public void CheckIfNetworkingEventsAreScheduled_Test()
        {
            int expectedNetworkingEvents = 1;

            foreach (Tracker track in conference)
            {
                Assert.AreEqual(expectedNetworkingEvents, track.Count(e => e is ScheduledNetworkingEvent));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlanConferenceWithUnplannableTalk_Test()
        {
            Talk veryLongEvent = new Talk(string.Empty, new Duration(300, new Minute()));
            talks.Add(veryLongEvent);
            conference = planner.GreedyBestFitApproach(talks);
        }
    }
}
