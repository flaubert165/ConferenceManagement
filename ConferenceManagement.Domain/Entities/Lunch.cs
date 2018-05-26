using ConferenceManagement.Common.Resources;

namespace ConferenceManagement.Domain.Entities
{
    public class Lunch : Talk
    {
        public Lunch()
            : base(Messages.Lunch, new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}