using System;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Constants;

namespace ConferenceManagement.Domain.Entities
{
    public class ScheduledTalk
    {
        public DateTime StartTime { get; private set; }
        public Talk OriginalTalk { get; private set; }

        public ScheduledTalk(Talk talk, DateTime start)
        {
            OriginalTalk = talk;
            StartTime = start;
        }

        public bool IsScheduledFor(Talk conferenceEvent)
        {
            return conferenceEvent.Equals(OriginalTalk);
        }

        public override string ToString()
        {
            return string.Concat(StartTime.ToString(AppSettings.DateTimeFormat), " ", OriginalTalk.ToString());
        }
    }
}