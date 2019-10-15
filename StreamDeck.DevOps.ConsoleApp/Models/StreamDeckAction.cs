using StreamDeck.DevOps.ConsoleApp.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class StreamDeckActionState : IStreamDeckActionState
    {
        public string Image { get; set; }

        public string TitleAlignment { get; set; }

        public string FontSize { get; set; }
    }

    public class StreamDeckAction : IStreamDeckAction
    {
        public string UUID { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public List<StreamDeckActionState> States { get; set; }

        public bool SupportedInMultiActions { get; set; }

        public string Tooltip { get; set; }
    }
}
