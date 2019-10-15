using StreamDeck.DevOps.ConsoleApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{
    public interface IReceivedEvent
    {
        ReceivedEventType Event { get; }
    }
}
