using ConferenceManagement.Common.Resources;
using ConferenceManagement.Domain.Entities.Constants;

namespace ConferenceManagement.Domain.Entities
{
    public class Lightning: TimeUnitManager
    {
        public override int ToMinutes(int amount)
        {
            return amount * AppSettings.LightningSessionDuration;
        }

        public override string ToString(int amount)
        {
            return Messages.Lightning;    
        }
    }
}