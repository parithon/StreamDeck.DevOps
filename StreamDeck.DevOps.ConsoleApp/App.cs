using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using StreamDeck.DevOps.ConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using StreamDeck.DevOps.ConsoleApp.Models;
using StreamDeck.DevOps.ConsoleApp.Core;
using System.Net.WebSockets;

namespace StreamDeck.DevOps.ConsoleApp
{
    public class App : IDisposable
    {
        private readonly ClientWebSocket _socket = new ClientWebSocket();

        public App(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ~App()
        {
            this.Dispose(false);
        }

        public IConfiguration Configuration { get; }

        [Option("-port <PORT>", CommandOptionType.SingleValue)]
        public int Port { get; } = -1;

        [Option("-pluginUUID <UUID>", CommandOptionType.SingleValue)]
        public string UUID { get; }

        [Option("-registerEvent <EVENT>", CommandOptionType.SingleValue)]
        public string Event { get; }

        [Option("-info <INFO>", CommandOptionType.SingleValue)]
        public string InfoJSON { get; }

        public IInfo Info => !string.IsNullOrWhiteSpace(InfoJSON) ? JsonConvert.DeserializeObject<InfoParameter>(InfoJSON) : null;

        public async Task OnExecuteAsync(CancellationToken cancellationToken)
        {
            if (Configuration.GetSection("AttachDebugger").Get<bool>() == true &&
                Info != null && 
                Info.Devices.Any(d => d.Type != StreamDeckType.StreamDeckTesting))                
            {
                Debugger.Launch();
            }
            
            try
            {
                await _socket.ConnectAsync(new Uri($"ws://localhost:{Port}"), cancellationToken);
                await _socket.SendAsync(GetPluginRegistrationBytes(), WebSocketMessageType.Text, true, cancellationToken);
            }
            catch (WebSocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (!cancellationToken.IsCancellationRequested && _socket.IsAvailable())
            {
                var buffer = new byte[65536];
                var segment = new ArraySegment<byte>(buffer, 0, buffer.Length);
                await _socket.ReceiveAsync(segment, cancellationToken);
                var receivedPayloadJSON = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

                if (!string.IsNullOrEmpty(receivedPayloadJSON) && !receivedPayloadJSON.StartsWith("\0"))
                {
                    var receivedPayload = JsonConvert.DeserializeObject<ReceivedPayload>(receivedPayloadJSON);
                    switch (receivedPayload.Event)
                    {
                        default:
                            break;
                    }
                }

                await Task.Delay(100);
            }

            ArraySegment<byte> GetPluginRegistrationBytes()
            {
                var registration = new
                {
                    @event = Event,
                    uuid = UUID
                };

                var outString = JsonConvert.SerializeObject(registration);
                var outBytes = Encoding.UTF8.GetBytes(outString);
                return new ArraySegment<byte>(outBytes);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _socket.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~App()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
