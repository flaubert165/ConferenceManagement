using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface ITalkConverter
    {
        Talk ConvertTalk(string obj);
    }
}