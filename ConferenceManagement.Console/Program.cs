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

namespace ConferenceManagement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // dependency injection service
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ITalkService, TalkService>()
            .AddSingleton<ITalkRepository, TalkRepository>()
            .AddSingleton<IConferencePlanningService, ConferencePlanningService>()
            .AddSingleton<IPrintService, PrintService>()
            .BuildServiceProvider();

            // services
            var _talkService = serviceProvider.GetService<ITalkService>();
            var _planningService = serviceProvider.GetService<IConferencePlanningService>();
            var _printService = serviceProvider.GetService<IPrintService>();
   
            // get input file
            string fileName = Directory.GetCurrentDirectory() + "/InputData/TestInput.txt";
            
            // verify if has entries
            if (args.Length > 0)
            {
                fileName = args[0];
            }

            try
            {
                var reader = _talkService.GetTalksFromTextFile(fileName);
                Conference conference = _planningService.GreedyBestFitApproach(reader);
                _printService.PrintResult(conference);

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

