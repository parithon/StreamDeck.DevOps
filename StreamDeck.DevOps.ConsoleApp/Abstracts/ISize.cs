using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Abstracts
{
    public interface ISize
    {
        int Rows { get; }
        int Columns { get; }
    }
}
