using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.MinesGameModels
{
    public interface IObserver
    {
        bool IsDanger(Point position);
        State Observe(Point position);
    }
}