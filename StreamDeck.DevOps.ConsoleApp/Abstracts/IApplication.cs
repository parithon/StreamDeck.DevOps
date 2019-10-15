using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{

    public interface IApplication
    {
        string Language { get; }
        string Platform { get; }
        string Version { get; }
    }
}
