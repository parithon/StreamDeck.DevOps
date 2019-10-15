using StreamDeck.DevOps.ConsoleApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Models
{
    public class Size : ISize
    {
        public int Rows { get; set; }

        public int Columns { get; set; }
    }
}
