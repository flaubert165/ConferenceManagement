using System.Collections.Generic;
using ConferenceManagement.Domain.Entities.Constants;

namespace ConferenceManagement.Domain.Entities
{
    public class TrackTwoSessions: BaseTrack
    {
        public TrackTwoSessions(string name)
            : base(name)
        {
            allSessions = new List<Session>
            {
                new Session(AppSettings.MorningSessionStartTime, AppSettings.MorningSessionEndTime),
                new Session(AppSettings.AfternoonSessionStartTime, AppSettings.AfternoonSessionEndTime)
            };
        }

        public override IEnumerator<ScheduledTalk> GetEnumerator()
        {
            return ExportSchedule().GetEnumerator();
        }

        private IEnumerable<ScheduledTalk> ExportSchedule()
        {
            foreach (ScheduledTalk talk in allSessions[0].EnumerateEvents())
            {
                yield return talk;
            }

            yield return new LunchInterval(new Lunch(), AppSettings.LunchIntervalStartTime);

            foreach (ScheduledTalk talk in allSessions[1].EnumerateEvents())
            {
                yield return talk;
            }

            if (allSessions[1].EndsBefore(AppSettings.NetworkingSessionRangeStartTime))
            {
                yield return new ScheduledNetworkingEvent(new NetworkingEvent(), AppSettings.NetworkingSessionRangeStartTime);
            }
            else
            {
                yield return new ScheduledNetworkingEvent(new NetworkingEvent(), AppSettings.NetworkingSessionRangeEndTime);
            }
        }
    }
}