using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface ITalkConverterService
    {
        Talk ConvertTalk(string obj);
    }
}