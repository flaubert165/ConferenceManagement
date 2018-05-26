using System.Collections;
using System.Collections.Generic;

namespace ConferenceManagement.Domain.Entities
{
    public abstract class BaseTrack : IEnumerable<ScheduledTalk>
    {
        protected string trackName;
        protected IList<Session> allSessions;

        public BaseTrack(string name)
        {
            trackName = name;
        }

        public override string ToString()
        {
            return trackName;
        }

        internal IEnumerable<Session> EnumerateSessions()
        {
            return allSessions;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract IEnumerator<ScheduledTalk> GetEnumerator();
        
    }
}