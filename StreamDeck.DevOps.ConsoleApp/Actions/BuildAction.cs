using StreamDeck.DevOps.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Actions
{
    [StreamDeckAction("dev.parithon.devops.build")]
    public class BuildAction : IStreamDeckAction
    {
        public string UUID => "dev.parithon.devops.build";

        public string Icon => "Resources/buildIcon";

        public string Name => "Build";

        public List<StreamDeckActionState> States => new List<StreamDeckActionState>
            {
                new StreamDeckActionState()
                {
                    Image = "Resources/buildIcon",
                    FontSize = "16",
                    TitleAlignment = "middle"
                }
            };

        public bool SupportedInMultiActions => false;

        public string Tooltip => "";
    }
}
