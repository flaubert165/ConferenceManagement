using System.IO;
using System.Collections.Generic;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.Services;
using ConferenceManagement.Infra.Input;
using System.Linq;

namespace ConferenceManagement.Infra
{
    public class TalkRepository : ITalkRepository
    {
        private LineConverter[] lineConverters;

        public TalkRepository()
        {
            lineConverters = new LineConverter[2];
            lineConverters[0] = new MinutesLineConverter();
            lineConverters[1] = new LightningLineConverter();
        }

        public IEnumerable<Talk> GetTalksFromTextFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            while(!sr.EndOfStream)
            {
                yield return ConvertTalk(sr.ReadLine());
            }
        }

        public Talk ConvertTalk(string data)
        {
            LineConverter parser = lineConverters.First(p => p.CanParse(data));
            return parser.Parse(data);
        }
    }
}