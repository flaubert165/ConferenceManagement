using System;
using System.Text.RegularExpressions;
using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Infra.Input
{
    public class MinutesLineConverter : LineConverter
    {
        private const string pattern = @"[0-9]*min$";

        public override bool CanParse(string line)
        {
            return Regex.IsMatch(line, pattern);
        }

        protected override LineConverter ParseName(string line)
        {
            talkName = line.Replace(GetAmountInMinuetes(line), "").Trim();
            return this;
        }

        protected override LineConverter ParseDuration(string line)
        {
            duration = new Duration(GetNumberOfMinutes(line), new Minute());
            return this;
        }

        private int GetNumberOfMinutes(string line)
        {
            return Convert.ToInt32(GetAmountInMinuetes(line).Replace("min", "").Trim());
        }

        private string GetAmountInMinuetes(string line)
        {
            return Regex.Match(line, pattern).Value;
        }
    }
}