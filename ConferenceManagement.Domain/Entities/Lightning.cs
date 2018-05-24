using System;
using ConferenceManagement.Domain.Entities.Constants;
using Microsoft.Extensions.Configuration;

namespace ConferenceManagement.Domain.Entities
{
    public class Lightning: TimeUnitManager
    {

        public Lightning()
        {
            
        }
        public override int ToMinutes(int amount)
        {
            return amount * 5;//AppSettings.LightningSessionDuration;
        }

        public override string ToString(int amount)
        {
            return "lightning";    
        }
    }
}