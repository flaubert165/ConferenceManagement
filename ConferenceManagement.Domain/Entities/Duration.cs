using System;
using Microsoft.Extensions.Configuration;

namespace ConferenceManagement.Domain.Entities
{
    public class Duration
    {
        IConfiguration _configuration;
        public int Value { get; private set; }
        public TimeUnitManager Unit { get; private set; }
        
        public Duration(int value, Minute unit)
        {
            Value = value;
            Unit = unit;
        }

        public Duration(Lightning lightning)
        {
            //var teste = this._configuration.GetSection("ConferenceInfo").GetSection("LightningSessionDuration").Value;
            Unit = lightning;
            Value = 5;
        }

        public int GetvalueInMinutes()
        {
            return Unit.ToMinutes(Value);
        }

        public override string ToString()
        {
            return Unit.ToString(Value);
        }
    }
}