using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{
    public interface IDeviceDidConnectEvent : IReceivedEvent
    {        
        string Device { get; }
        
        IDevice DeviceInfo { get; }
    }
}
