using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface IPrintService
    {
        void PrintInitialMessage();
        void PrintResult(Conference conference);
        void PrintEndMessage();
    }
}