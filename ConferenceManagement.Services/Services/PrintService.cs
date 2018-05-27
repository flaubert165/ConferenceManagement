using System;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Services;

namespace ConferenceManagement.Services
{
    public class PrintService : IPrintService
    {
        public void PrintInitialMessage()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("              Welcome to Conference Manager                        ");
            Console.WriteLine("===================================================================" + Environment.NewLine);
            Console.WriteLine("Now, the input file data are processed. Please wait for the result:" + Environment.NewLine);
        }

        public void PrintResult(Conference conference)
        {
            Console.WriteLine();
            
            foreach (Tracker conferenceItem in conference)
            {
                Console.WriteLine(conferenceItem);

                foreach(ScheduledTalk conferenceTalk in conferenceItem)
                {
                    Console.WriteLine(conferenceTalk);
                }
                Console.WriteLine();
            }
        }

        public void PrintEndMessage()
        {
            Console.WriteLine("Finished! Press any key to exit! Thanks =)");
            Console.Read();
        }
    }
}