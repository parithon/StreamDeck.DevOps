using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using StreamDeck.DevOps.ConsoleApp.Actions;
using StreamDeck.DevOps.ConsoleApp.Models;

namespace StreamDeck.DevOps.ConsoleApp
{
    class StreamDeckActionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IStreamDeckAction);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(StreamDeckAction));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    class Program
    {
        static Task<int> Main(string[] args)
        {
            if (args.Any(arg => arg.ToLower() == "--generatemanifest"))
            {
                return Task.Run(async () => {
                    var manifestJSON = await File.ReadAllTextAsync("manifest.json");
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    settings.Converters.Add(new StreamDeckActionConverter());
                    var manifest = JsonConvert.DeserializeObject<Manifest>(manifestJSON, settings);
                    manifest.Actions.Clear();
                    var actionsByType = typeof(Program).Assembly.GetTypes().Where(t => t.IsClass && t.CustomAttributes.Any(a => a.AttributeType == typeof(StreamDeckActionAttribute)));
                    foreach (var actionType in actionsByType)
                    {
                        var action = Activator.CreateInstance(actionType);
                        manifest.Actions.Add(action as IStreamDeckAction);
                    }
                    var newManifestJSON = JsonConvert.SerializeObject(manifest);
                    await File.WriteAllTextAsync("manifest.json", newManifestJSON, System.Text.Encoding.UTF8);
                    return 0;
                });
            }

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
