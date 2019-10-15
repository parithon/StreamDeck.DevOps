using StreamDeck.DevOps.ConsoleApp.Abstracts;
using StreamDeck.DevOps.ConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class InfoParameter : IInfo
    {
        public Application Application { get; set; }

        public PluginInfo Plugin { get; set; }

        public int DevicePixelRatio { get; set; }

        public List<Device> Devices { get; set; }

        IApplication IInfo.Application => this.Application;
        IPluginInfo IInfo.Plugin => this.Plugin;
        IEnumerable<IDevice> IInfo.Devices => this.Devices;
    }
}
