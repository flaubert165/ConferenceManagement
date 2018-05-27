using System;

namespace ConferenceManagement.Domain.Entities
{
    public class Talk : IComparable
    {
        public string Name { get; private set; }
        public Duration Duration { get; private set; }

        public Talk(string name, Duration duration)
        {
            this.Name = name;
            this.Duration = duration;
        }

        public int DurationInMinutes()
        {
            return Duration.GetValueInMinutes();
        }

        public override string ToString()
        {
            return string.Concat(Name, " ", Duration);
        }

        public override bool Equals(object obj)
        {
            Talk conferenceEvent = obj as Talk;

            if(conferenceEvent == null)
            {
                return false;
            }

            return Name.Equals(conferenceEvent.Name);
        }

        public override int GetHashCode()
        {
            return new { Name }.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Talk otherTalk = obj as Talk;

            return otherTalk.DurationInMinutes() - DurationInMinutes();
        }
    }
}