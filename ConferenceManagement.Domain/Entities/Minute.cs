namespace ConferenceManagement.Domain.Entities
{
    public class Minute : TimeUnitManager
    {
         public override int ToMinutes(int amount)
        {
            return amount;
        }

        public override string ToString(int amount)
        {
            return string.Concat(amount, "min");
        }
    }
}