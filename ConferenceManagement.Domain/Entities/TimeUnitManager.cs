namespace ConferenceManagement.Domain.Entities
{
    public abstract class TimeUnitManager
    {
        public abstract int ToMinutes(int amount);
        public abstract string ToString(int amount);
    }
}