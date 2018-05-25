using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface IPrintService
    {
         void PrintResult(Conference conference);
    }
}