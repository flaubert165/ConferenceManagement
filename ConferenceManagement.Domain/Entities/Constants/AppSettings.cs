using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace ConferenceManagement.Domain.Entities.Constants
{
    public static class AppSettings
    {
        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app.settings.json", optional: true, reloadOnChange: true);
                return builder.Build();
            }
        }

        public static DateTime MorningSessionStartTime 
        {
            get
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("MorningSessionStartTime").Value);
            }
        }

        public static DateTime MorningSessionEndTime 
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("MorningSessionEndTime").Value);
            }
        }

        public static DateTime AfternoonSessionStartTime 
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("AfternoonSessionStartTime").Value);
            }
        }

        public static DateTime AfternoonSessionEndTime 
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("AfternoonSessionEndTime").Value);
            }
        }

        public static DateTime LunchIntervalStartTime
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("LunchIntervalStartTime").Value);
            }
        }

        public static DateTime LunchIntervalEndTime
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("LunchIntervalEndTime").Value);
            }
        }

        public static DateTime NetworkingSessionRangeStartTime
        {
            get 
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("NetworkingSessionRangeStartTime").Value);
            }
        }

        public static DateTime NetworkingSessionRangeEndTime
        {
            get
            {
                return DateTime.Parse(Configuration.GetSection("ConferenceInfo").GetSection("NetworkingSessionRangeEndTime").Value);
            }
        }

        public static int LightningSessionDuration
        {
            get
            {
                return int.Parse(Configuration.GetSection("ConferenceInfo").GetSection("LightningSessionDuration").Value);
            }
        }

        public static string DateTimeFormat
        {
            get
            {
                return Configuration.GetSection("ConferenceInfo").GetSection("DateTimeFormat").Value;
            }
        }
    }
}