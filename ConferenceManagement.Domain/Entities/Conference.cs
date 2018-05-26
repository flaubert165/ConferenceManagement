using System.Collections.Generic;
using ConferenceManagement.Common.Resources;
using ConferenceManagement.Domain.Entities.Factories;

namespace ConferenceManagement.Domain.Entities
{
    public class Conference: IEnumerable<BaseTrack>
    {
        private ITrackFactory trackFactory;
        private IList<BaseTrack> tracks;

        public Conference(ITrackFactory factory)
        {
            tracks = new List<BaseTrack>();
            trackFactory = factory;
        }

        public void CreateNewTrack()
        {
            tracks.Add(trackFactory.CreateTrack(ProvideNextTrackName()));
        }

        public IEnumerable<Session> EnumerateSessions()
        {
            foreach (BaseTrack track in tracks)
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

        public IEnumerator<BaseTrack> GetEnumerator()
        {
            return tracks.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}