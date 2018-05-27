using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class SessionTests
    {
        private DateTime sessionStartTime;
        private DateTime sessionEndTime;

        [TestInitialize]
        public void SetUp()
        {
            sessionStartTime = DateTime.Parse("09:00:00AM");
            sessionEndTime = DateTime.Parse("10:00:00AM");
        }

        [TestMethod]
        public void CanAcceptEvent_ExpectedTrue_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            Talk halfHourEvent = new Talk(string.Empty, new Duration(30, new Minute()));

            Assert.IsTrue(session.CanAcceptTalk(halfHourEvent));
        }

        [TestMethod]
        public void CanAcceptEvent_ExpectedFalse_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            Talk twoHourEvent = new Talk(string.Empty, new Duration(120, new Minute()));

            Assert.IsFalse(session.CanAcceptTalk(twoHourEvent));
        }

        [TestMethod]
        public void AcceptEvent_EventAccepted_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            Talk talk = new Talk(string.Empty, new Duration(new Lightning()));

            session.AcceptTalk(talk);
            IList<ScheduledTalk> allEvents = new List<ScheduledTalk>(session.EnumerateEvents());

            Assert.IsTrue(allEvents.Any(e => e.IsScheduledFor(talk)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AcceptEvent_ExceptionThrown_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            Talk talk = new Talk(string.Empty, new Duration(120, new Minute()));

            session.AcceptTalk(talk);

            Assert.Fail();
        }

        [TestMethod]
        public void EndsBefore_ExpectedTrue_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            DateTime dateTime = DateTime.Parse("12:00:00 PM");

            Assert.IsTrue(session.EndsBefore(dateTime));
        }

        [TestMethod]
        public void EndsBefore_ExpectedFalse_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            DateTime dateTime = DateTime.Parse("08:59:00 AM");

            Assert.IsFalse(session.EndsBefore(dateTime));
        }

        [TestMethod]
        public void UnusedTime_Test()
        {
            Session session = new Session(sessionStartTime, sessionEndTime);
            Talk talk = new Talk(string.Empty, new Duration(30, new Minute()));

            session.AcceptTalk(talk);
            TimeSpan unusedTime = session.TimeLeft();

            Assert.IsTrue(unusedTime.TotalMinutes == 30);
        }
    }
}
