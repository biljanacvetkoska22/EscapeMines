using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.MinesGameModels
{
    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    public enum State
    {
        IsDead,
        Normal,
        IsOutOfBounds,
        IsExit,
        IsDanger
    }
}
