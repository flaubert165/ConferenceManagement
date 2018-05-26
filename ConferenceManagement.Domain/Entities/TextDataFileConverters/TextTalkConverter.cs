using System.Linq;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Services;

namespace ConferenceManagement.Infra.Input
{
    public class TextTalkConverter : ITalkConverterService
    {
        private LineConverter[] lineConverters;

        public TextTalkConverter()
        {
            lineConverters = new LineConverter[2];
            lineConverters[0] = new MinutesLineConverter();
            lineConverters[1] = new LightningLineConverter();
        }

        public Talk ConvertTalk(string data)
        {
            LineConverter parser = lineConverters.First(p => p.CanParse(data));
            return parser.Parse(data);
        }
    }
}