using System;
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
        public static IConfiguration Configuration { get; set; }
        
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("app.settings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
            .AddSingleton<ITalkService, TalkService>()
            .AddSingleton<ITalkRepository, TalkRepository>()
            .AddSingleton<IConferencePlanning, ConferencePlanning>()
            .AddSingleton<IConfiguration>(Configuration)
            .BuildServiceProvider();
            
            // services
            var _talkService = serviceProvider.GetService<ITalkService>();
            var _planningService = serviceProvider.GetService<IConferencePlanning>();
   
            string fileName = Directory.GetCurrentDirectory() + "/InputData/TestInput.txt";
            
            
            // verify if has entries
            if (args.Length > 0)
            {
                fileName = args[0];
            }

            try
            {
                // return IEnumerable of Talks
                var reader = _talkService.GetTalksFromTextFile(fileName);
                Conference conference = _planningService.GreedyBestFitApproach(reader);
                
                foreach (var item in reader)
                {
                    System.Console.WriteLine(item.Name);
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
            System.Console.WriteLine("Press \"Enter\" to exit");
            System.Console.ReadLine();
        }
    }
}

