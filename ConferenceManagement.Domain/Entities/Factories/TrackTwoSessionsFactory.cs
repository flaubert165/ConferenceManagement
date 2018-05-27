namespace ConferenceManagement.Domain.Entities.Factories
{
    public class TrackTwoSessionsFactory: ITrackFactory
    {
        public Tracker CreateTrack(string trackName)
        {
            return new TrackTwoSessions(trackName);
        }
    }
}