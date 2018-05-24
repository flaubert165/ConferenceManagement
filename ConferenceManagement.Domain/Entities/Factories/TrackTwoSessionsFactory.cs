namespace ConferenceManagement.Domain.Entities.Factories
{
    public class ITrackTwoSessionsFactory: ITrackFactory
    {
        public BaseTrack CreateTrack(string trackName)
        {
            return new TrackTwoSessions(trackName);
        }
    }
}