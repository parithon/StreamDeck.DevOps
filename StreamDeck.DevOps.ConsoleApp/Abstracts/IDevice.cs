using StreamDeck.DevOps.ConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{
    public interface IDevice
    {
        string Id { get; }
        string Name { get; }
        ISize Size { get; }
        StreamDeckType Type { get; }
    }
}
