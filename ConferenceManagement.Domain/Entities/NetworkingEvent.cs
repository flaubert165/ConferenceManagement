using ConferenceManagement.Common.Resources;

namespace ConferenceManagement.Domain.Entities
{
    public class NetworkingEvent : Talk
    {
        public NetworkingEvent()
            : base(Messages.NetworkingEvent, new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}