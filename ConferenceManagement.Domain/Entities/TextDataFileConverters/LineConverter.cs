using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Infra.Input
{
    public abstract class LineConverter
    {
        protected string talkName;
        protected Duration duration;

        public Talk Parse(string line)
        {
            return ParseName(line)
                    .ParseDuration(line)
                    .Build();
        }
        
        protected virtual Talk Build()
        {
            return new Talk(talkName, duration);
        }

        public abstract bool CanParse(string line);
        protected abstract LineConverter ParseName(string line);
        protected abstract LineConverter ParseDuration(string line);
    }
}