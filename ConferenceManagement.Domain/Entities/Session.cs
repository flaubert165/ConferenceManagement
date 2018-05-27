using System;
using System.Collections;
using System.Collections.Generic;
using ConferenceManagement.Common.Resources;

namespace ConferenceManagement.Domain.Entities
{
    public class Session: IEnumerable<ScheduledTalk>
    {
        private DateTime sessionStartTime;
        private DateTime sessionEndTime;
        private DateTime lastTalkEndsTime;

        private IList<ScheduledTalk> sessionEvents;

        public Session(DateTime start, DateTime end)
        {
            sessionStartTime = start;
            sessionEndTime = end;
            lastTalkEndsTime = start;
            sessionEvents = new List<ScheduledTalk>();
        }

        public TimeSpan GetSessionDuration()
        {
            return sessionEndTime.Subtract(sessionStartTime);
        }

        public TimeSpan TimeLeft()
        {
            return sessionEndTime.Subtract(lastTalkEndsTime);
        }

        public bool EndsBefore(DateTime time)
        {
            return lastTalkEndsTime <= time;
        }

        public IEnumerable<ScheduledTalk> EnumerateEvents()
        {
            return sessionEvents;
        }

        public bool CanAcceptTalk(Talk talk)
        {
            return TimeLeft().TotalMinutes >= talk.DurationInMinutes();
        }

        public void AcceptTalk(Talk talk)
        {
            if(CanAcceptTalk(talk))
            {
                sessionEvents.Add(new ScheduledTalk(talk, lastTalkEndsTime));
                lastTalkEndsTime = lastTalkEndsTime.AddMinutes(talk.DurationInMinutes());
                return;
            }

            throw new InvalidOperationException(Messages.NotEnoughTimeInSessionError);
        }

        public IEnumerator<ScheduledTalk> GetEnumerator()
        {
            return sessionEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}