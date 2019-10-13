using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.MinesGameModels
{
    public interface IGrid
    {
        Element this[Point p] { get; set; }
        Element this[int index1, int index2] { get; set; }

        int Height { get; }
        int Width { get; }
    }
}