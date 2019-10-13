using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.MinesGameModels
{
    public interface ITurtle
    {
        Directions Direction { get; set; }

        void Move();
        void RotateLeft();
        void RotateRight();
    }
}