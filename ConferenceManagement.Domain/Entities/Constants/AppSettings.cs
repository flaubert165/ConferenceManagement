using System;
using Microsoft.Extensions.Configuration;

namespace ConferenceManagement.Domain.Entities.Constants
{
    public static class AppSettings
    {
        // CORRIGIR CÓDIGO PARA ACESSAR E RESGATAR OS VALORES DE APP.SETTINGS>JSON
        private static IConfiguration Configuration;

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

        public static int MinutesInLightning
        {
            get
            {
                return int.Parse(Configuration.GetSection("ConferenceInfo").GetSection("MinutesInLightning").Value);
            }
        }

        public static int LightningSessionDuration
        {
            get
            {
                return int.Parse(Configuration["ConferenceInfo:LightningSessionDuration"]);
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