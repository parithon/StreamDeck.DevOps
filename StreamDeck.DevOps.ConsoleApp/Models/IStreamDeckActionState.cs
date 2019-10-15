using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public interface IStreamDeckActionState
    {
        string Image { get; }
        string TitleAlignment { get; }
        string FontSize { get; }
    }
}
