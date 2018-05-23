using System;

namespace ConferenceManagement.Domain.Entities
{
    public class Talk
    {
        public string Name { get; private set; }
        public Duration Duration { get; private set; }

        public Talk(string name, Duration duration)
        {
            SetName(name);
            SetDuration(duration);
        }

        private void SetDuration(Duration duration)
        {
            this.Duration = duration;
        }

        private void SetName(string name)
        {
            this.Name = name;
        }
    }
}