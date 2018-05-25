using System;
using ConferenceManagement.Domain.Entities.Constants;

namespace ConferenceManagement.Domain.Entities
{
    public class LunchInterval : ScheduledTalk
    {
        public LunchInterval(Lunch lunch, DateTime start)
            : base(lunch, start)
        {
            if(start != AppSettings.LunchIntervalStartTime)
            {
                throw new ArgumentOutOfRangeException("ErrorLunchStartTime");
            }
        }
    }
}