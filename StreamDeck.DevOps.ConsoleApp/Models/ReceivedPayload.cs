using Newtonsoft.Json;
using StreamDeck.DevOps.ConsoleApp.Abstracts;
using StreamDeck.DevOps.ConsoleApp.Core;
using System;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class ReceivedPayload : IReceivedEvent, IDeviceDidConnectEvent
    {
        [JsonProperty("event")]
        public string EventString { get; set; }

        public ReceivedEventType Event => !string.IsNullOrEmpty(EventString) ? Enum.Parse<ReceivedEventType>(EventString) : ReceivedEventType.unknown;

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("deviceInfo")]
        public Device DeviceInfo { get; set; }
        IDevice IDeviceDidConnectEvent.DeviceInfo => this.DeviceInfo;
    }
}
