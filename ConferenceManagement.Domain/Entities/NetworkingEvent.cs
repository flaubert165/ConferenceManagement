namespace ConferenceManagement.Domain.Entities
{
    public class NetworkingEvent : Talk
    {
        public NetworkingEvent()
            : base("Strings.NetworkingEvent", new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}