namespace ConferenceManagement.Domain.Entities
{
    public class Lunch : Talk
    {
        public Lunch()
            : base("Lunch", new EmptyOrNullDuration())
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}