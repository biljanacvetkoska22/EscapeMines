using System.Collections.Generic;
using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.ReadModels
{
    public interface IReadSettingsModel
    {
        string Direction { get; set; }
        Point ExitPoint { get; set; }
        List<Point> MinePoints { get; set; }
        string[] Moves { get; set; }
        Point Size { get; set; }
        Point StartPoint { get; set; }
    }
}