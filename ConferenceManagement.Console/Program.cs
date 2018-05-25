using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.Services;
using ConferenceManagement.Infra;
using ConferenceManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Services.BinPackingLogic;
using ConferenceManagement.Common.Validations;

namespace ConferenceManagement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Directory.GetCurrentDirectory() + "/InputData/TestInput.txt";
            
            Guard.ForNullOrEmptyDefaultMessage(file, "The data file");

            try
            {
                
                /**
                    The talks variable represents an Enumerable<Talks>.
                 */
                var talks = Startup.ServiceProvider
                                    .GetService<ITalkService>()
                                    .GetTalksFromTextFile(file);

                /**
                    The conference variable representes an Conference object instance.    
                */                                                        
                var conference = Startup
                                    .ServiceProvider
                                    .GetService<IConferencePlanningService>()
                                    .GreedyBestFitApproach(talks);

                /**
                    The PrintService prints the result of the process.
                 */
                Startup.ServiceProvider
                                    .GetService<IPrintService>()
                                    .PrintResult(conference);

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
            System.Console.WriteLine("Finished! Press any key to exit! Thanks =)");
            System.Console.Read();
        }
    }
}

