using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface ITalkService
    {
        IEnumerable<Talk> GetTalksFromTextFile(string fileName);
    }
}