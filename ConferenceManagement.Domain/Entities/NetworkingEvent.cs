namespace ConferenceManagement.Domain.Entities
{
    public class NetworkingEvent : Talk
    {
        public NetworkingEvent()
            : base("Networking Event", new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}