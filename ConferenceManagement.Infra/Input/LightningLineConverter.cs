using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Infra.Input
{
    public class LightningLineConverter : LineConverter
    {
        public override bool CanParse(string line)
        {
            return line.EndsWith("lightning");
        }

        protected override LineConverter ParseName(string line)
        {
            talkName = line.Replace("lightning", "").Trim();
            return this;
        }

        protected override LineConverter ParseDuration(string line)
        {
            duration = new Duration(new Lightning());
            return this;
        }
    }
}