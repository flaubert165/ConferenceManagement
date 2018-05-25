using System;
using Microsoft.Extensions.Configuration;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Constants;

namespace ConferenceManagement.Domain.Entities
{
    public class Duration
    {
        public int Value { get; private set; }
        public TimeUnitManager Unit { get; private set; }
        
        public Duration(int value, Minute unit)
        {
            Value = value;
            Unit = unit;
        }

        public Duration(Lightning lightning)
        {
            Unit = lightning;
            Value = 1;
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