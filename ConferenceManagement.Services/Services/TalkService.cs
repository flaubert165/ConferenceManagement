using System.Collections.Generic;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.Services;

namespace ConferenceManagement.Services
{
    public class TalkService : ITalkService
    {
        ITalkRepository _repository;

        public TalkService(ITalkRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Talk> GetTalksFromTextFile(string fileName)
        {
            return this._repository.GetTalksFromTextFile(fileName);
        }
    }
}