using EscapeMines.Common.MinesGameModels;

namespace EscapeMines.Common.Interfaces.MinesGameModels
{
    public interface IGame
    {
        bool Validate();
        State Start();
        void Dispose();
    }
}