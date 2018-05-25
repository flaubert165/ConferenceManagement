using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Services;

namespace ConferenceManagement.Services
{
    public class PrintService : IPrintService
    {
        public void PrintResult(Conference conference)
        {
            System.Console.WriteLine();
            
            foreach (BaseTrack conferenceItem in conference)
            {
                System.Console.WriteLine(conferenceItem);

                foreach(ScheduledTalk conferenceTalk in conferenceItem)
                {
                    System.Console.WriteLine(conferenceTalk);
                }
                System.Console.WriteLine();
            }
        }
    }
}