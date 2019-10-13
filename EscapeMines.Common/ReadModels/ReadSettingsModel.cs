using EscapeMines.Common.Interfaces.ReadModels;
using EscapeMines.Common.MinesGameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.ReadModels
{
    public class ReadSettingsModel : IReadSettingsModel
    {
        public Point Size { get; set; }
        public Point StartPoint { get; set; }
        public Point ExitPoint { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        public string Direction { get; set; }
        public string[] Moves { get; set; }
    }
}
