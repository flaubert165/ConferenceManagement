using System.Collections.Generic;
using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories
{
    public interface ITalkRepository
    {
        IEnumerable<Talk> GetTalksFromTextFile(string fileName);
    }
}