using System.IO;
using ConferenceManagement.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using ConferenceManagement.Common.Validations;
using ConferenceManagement.Common.Resources;
using System;

namespace ConferenceManagement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Directory.GetCurrentDirectory() + "/InputData/TestInput.txt";

            Guard.ForNullOrEmpty(file, Messages.FileNotFound);

            try
            {
                Startup.ServiceProvider.GetService<IPrintService>().PrintInitialMessage();

                var talks = Startup.ServiceProvider
                                    .GetService<ITalkService>()
                                    .GetTalksFromTextFile(file);

                Guard.IEnumerableIsNullOrEmpty(talks);

                var conference = Startup
                                    .ServiceProvider
                                    .GetService<IConferencePlanningService>()
                                    .GreedyBestFitApproach(talks);


                Startup.ServiceProvider.GetService<IPrintService>().PrintResult(conference);

                Startup.ServiceProvider.GetService<IPrintService>().PrintEndMessage();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}

