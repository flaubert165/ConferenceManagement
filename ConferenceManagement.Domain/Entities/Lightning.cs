using System;
using Microsoft.Extensions.Configuration;

namespace ConferenceManagement.Domain.Entities
{
    public class Lightning: TimeUnitManager
    {
        public IConfiguration _configuration { get; }

        public Lightning()
        {
            
        }
        public override int ToMinutes(int amount)
        {
            //var teste = this._configuration.GetSection("ConferenceInfo").GetSection("LightningSessionDuration").Value;
            return amount * 5;
        }

        public override string ToString(int amount)
        {
            return "lightning";    
        }
    }
}