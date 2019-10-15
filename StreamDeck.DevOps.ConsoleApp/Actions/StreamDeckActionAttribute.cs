using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Actions
{
    public sealed class StreamDeckActionAttribute : Attribute
    {
        public StreamDeckActionAttribute(string uuid)
        {
            UUID = uuid;
        }

        public string UUID { get; }
    }
}
