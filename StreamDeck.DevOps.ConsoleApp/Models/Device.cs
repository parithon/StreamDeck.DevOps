using StreamDeck.DevOps.ConsoleApp.Abstracts;
using StreamDeck.DevOps.ConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class Device : IDevice
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Size Size { get; set; }

        public StreamDeckType Type { get; set; }

        ISize IDevice.Size => this.Size;
    }
}
