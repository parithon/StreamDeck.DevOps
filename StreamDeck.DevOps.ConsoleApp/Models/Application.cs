using StreamDeck.DevOps.ConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class Application : IApplication
    {
        public string Language { get; set; }

        public string Platform { get; set; }

        public string Version { get; set; }
    }
}
