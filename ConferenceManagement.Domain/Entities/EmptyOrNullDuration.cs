namespace ConferenceManagement.Domain.Entities
{
    public class EmptyOrNullDuration : Duration
    {
        public EmptyOrNullDuration()
            : base(0, null)
        {

        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}