namespace ConferenceManagement.Domain.Entities
{
    public class Lunch : Talk
    {
        public Lunch()
            : base("Strings.Lunch", new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}