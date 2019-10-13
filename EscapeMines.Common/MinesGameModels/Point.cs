using EscapeMines.Common.Interfaces.MinesGameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.MinesGameModels
{
    public struct Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
