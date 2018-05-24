namespace ConferenceManagement.Domain.Entities.Factories
{
    public interface ITrackFactory
    {
        BaseTrack CreateTrack(string trackName);
    }
}