using System.Collections;
using System.Collections.Generic;
using ConferenceManagement.Common.Resources;
using ConferenceManagement.Domain.Entities.Factories;

namespace ConferenceManagement.Domain.Entities
{
    public class Conference: IEnumerable<Tracker>
    {
        private ITrackFactory trackFactory;
        private IList<Tracker> tracks;

        public Conference(ITrackFactory factory)
        {
            tracks = new List<Tracker>();
            trackFactory = factory;
        }

        public void CreateNewTrack()
        {
            tracks.Add(trackFactory.CreateTrack(ProvideNextTrackName()));
        }

        public IEnumerable<Session> EnumerateSessions()
        {
            foreach (Tracker track in tracks)
            {
                foreach (Session session in track.EnumerateSessions())
                {
                    yield return session;
                }
            }
        }

        private string ProvideNextTrackName()
        {
            return string.Format(Messages.TrackNameFormat, tracks.Count + 1,  ":");
        }

        public IEnumerator<Tracker> GetEnumerator()
        {
            return tracks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}