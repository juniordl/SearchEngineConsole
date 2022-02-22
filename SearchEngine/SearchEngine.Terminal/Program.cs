using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchEngine.Core;
using SearchEngine.Core.Interfaces;
using SearchEngine.Core.Service;
using SearchEngine.Infrastructure;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SearchEngine.Terminal
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static async Task Main(string[] args) {

            configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();

            var builder = new HostBuilder();

            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IConfigurationRoot>(configuration);
                services.AddScoped<IConfigService, ConfigService>();
                services.AddScoped<IRequestService, RequestService>();
                services.AddScoped<ISearchService, SearchService>();
                services.AddScoped<IHighlightsOutput, HighlightsOutput>();
                services.AddScoped<SearchFight>();
            });

            var host = builder.Build();
            using (host) {
                var processor = host.Services.GetRequiredService<SearchFight>();
                await processor.Search(args);
            }
        }
    }
}
