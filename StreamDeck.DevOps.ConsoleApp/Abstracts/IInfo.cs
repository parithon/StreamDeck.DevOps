using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{
    public interface IInfo
    {
        IApplication Application { get; }
        IPluginInfo Plugin { get; }
        int DevicePixelRatio { get; }
        IEnumerable<IDevice> Devices { get; }
    }
}
