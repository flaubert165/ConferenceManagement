namespace ConferenceManagement.Domain.Entities.Factories
{
    public interface ITrackFactory
    {
        Tracker CreateTrack(string trackName);
    }
}