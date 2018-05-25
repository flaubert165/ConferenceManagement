namespace ConferenceManagement.Domain.Entities.Factories
{
    public class TrackTwoSessionsFactory: ITrackFactory
    {
        public BaseTrack CreateTrack(string trackName)
        {
            return new TrackTwoSessions(trackName);
        }
    }
}