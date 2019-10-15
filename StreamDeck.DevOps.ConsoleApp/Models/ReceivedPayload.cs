using Newtonsoft.Json;
using StreamDeck.DevOps.ConsoleApp.Abstracts;
using StreamDeck.DevOps.ConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class ReceivedPayload : IReceivedEvent
    {
        [JsonProperty("event")]
        public string EventString { get; set; }

        public ReceivedEventType Event => !string.IsNullOrEmpty(EventString) ? Enum.Parse<ReceivedEventType>(EventString) : ReceivedEventType.unknown;
    }
}
