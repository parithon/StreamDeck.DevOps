using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public interface IStreamDeckAction
    {
        string UUID { get; }
        string Icon { get; }
        string Name { get; }
        List<StreamDeckActionState> States { get; }
        bool SupportedInMultiActions { get; }
        string Tooltip { get; }
    }
}
