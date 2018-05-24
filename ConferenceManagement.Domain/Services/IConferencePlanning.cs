using System.Collections.Generic;
using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Services
{
    public interface IConferencePlanning
    {
         Conference GreedyBestFitApproach(IEnumerable<Talk> talks);

         Conference GreedyFirstFitApproach(IEnumerable<Talk> talks);
    }
}