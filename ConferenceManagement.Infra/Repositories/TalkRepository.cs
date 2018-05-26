using System.Collections.Generic;
using System.IO;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.Services;
using ConferenceManagement.Infra.Input;

namespace ConferenceManagement.Infra
{
    public class TalkRepository : ITalkRepository
    {
        private ITalkConverterService talkConverterService;

        public TalkRepository()
        {
            talkConverterService = new TextTalkConverter();
        }

        public IEnumerable<Talk> GetTalksFromTextFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            while(!sr.EndOfStream)
            {
                yield return talkConverterService.ConvertTalk(sr.ReadLine());
            }
        }
    }
}