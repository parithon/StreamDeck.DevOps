using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StreamDeck.DevOps.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .RunCommandLineApplicationAsync<App>(args);
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
