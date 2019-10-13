using EscapeMines.Common.Interfaces.MinesGameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.MinesGameModels
{
    // Other classes are inheriting this class because we want to achieve code reusability
    public class Element : IElement
    {
        public Point Position { get; set; }
    }
}
