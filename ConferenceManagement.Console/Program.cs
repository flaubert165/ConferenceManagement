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
            .AddSingleton<IConfiguration>(Configuration)
            .BuildServiceProvider();
            
            // services
            var _talkService = serviceProvider.GetService<ITalkService>();

            string rootPath = Directory.GetCurrentDirectory();    
            string fileName = @"/Users/italosantana/Desktop/ConferenceManagement/ConferenceManagement.Console/InputData/TestInput.txt";
            
            // verify if has entries
            if (args.Length > 0)
            {
                fileName = args[0];
            }

            try
            {
                // return IEnumerable of Talks
                var reader = _talkService.GetTalksFromTextFile(fileName);
                    
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

