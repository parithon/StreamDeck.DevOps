using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using System.Threading.Tasks;

namespace StreamDeck.DevOps.ConsoleApp
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .Build();

            var app = new CommandLineApplication<App>();
            
            app.Conventions
               .UseDefaultConventions()
               .UseConstructorInjection(host.Services);

            return app.ExecuteAsync(args);
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = new HostBuilder();

            builder.ConfigureAppConfiguration((hostingContext, config) => {
                var env = hostingContext.HostingEnvironment;

                config.SetBasePath(Directory.GetCurrentDirectory());

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
                      .AddEnvironmentVariables();
            });

            builder.ConfigureLogging((hostingContext, logging) => {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddEventSourceLogger();
            });

            return builder;
        }
            
    }
}
