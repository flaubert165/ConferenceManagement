using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.Services;
using ConferenceManagement.Infra;
using ConferenceManagement.Services;
using ConferenceManagement.Services.BinPackingLogic;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceManagement.Console
{
    public static class Startup
    {
        public static ServiceProvider ServiceProvider
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                        .AddSingleton<ITalkService, TalkService>()
                        .AddSingleton<ITalkRepository, TalkRepository>()
                        .AddSingleton<IConferencePlanningService, ConferencePlanningService>()
                        .AddSingleton<IPrintService, PrintService>()
                        .BuildServiceProvider();

                return serviceProvider;
            }

        }
    }
}