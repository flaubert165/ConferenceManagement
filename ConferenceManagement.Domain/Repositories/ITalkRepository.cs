using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories
{
    public interface ITalkRepository
    {
        IEnumerable<Talk> GetTalksFromTextFile(string fileName);
    }
}