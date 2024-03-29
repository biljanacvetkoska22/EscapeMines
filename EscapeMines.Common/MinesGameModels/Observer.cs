﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EscapeMines.Common.Interfaces.MinesGameModels;

namespace EscapeMines.Common.MinesGameModels
{
    
    public class Observer : IObserver
    {
        private int _width;
        private int _height;
        private IGrid _grid;

        /// <summary>
        /// Another example of loosely coupled classes with dependency injection
        /// constructor injection
        /// </summary>
        public Observer(IGrid grid)
        {
            _width = grid.Width;
            _height = grid.Height;
            _grid = grid;
        }

        /// <summary>
        /// Observe the game situation after a turtle operation
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public State Observe(Point position)
        {
            if (IsOutOfBounds(position)) return State.IsOutOfBounds;
            else if (IsExit(position)) return State.IsExit;
            else if (IsDead(position)) return State.IsDead;
            else if (IsDanger(position)) return State.IsDanger;
            else return State.Normal;
        }

        public bool IsDanger(Point position)
        {
            var adjacentPoints = GetAdjacentPositions(position);
            return adjacentPoints.Any(x => _grid[position] is Mine);
        }

        private bool IsDead(Point position)
        {
            return _grid[position] is Mine;
        }

        private bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.X >= _height || position.Y < 0 || position.Y >= _width;
        }

        private bool IsExit(Point position)
        {
            return _grid[position] is Exit;
        }

        private List<Point> GetAdjacentPositions(Point position)
        {
            var list = new List<Point>();

            if (position.X - 1 >= 0) list.Add(new Point { X = position.X - 1, Y = position.Y });
            if (position.X - 1 >= 0 && position.Y - 1 >= 0) list.Add(new Point { X = position.X - 1, Y = position.Y - 1 });
            if (position.X - 1 >= 0 && position.Y + 1 < _width) list.Add(new Point { X = position.X - 1, Y = position.Y + 1 });
            if (position.X + 1 < _height) list.Add(new Point { X = position.X + 1, Y = position.Y });
            if (position.X + 1 < _height && position.Y - 1 >= 0) list.Add(new Point { X = position.X + 1, Y = position.Y - 1 });
            if (position.X + 1 < _height && position.Y + 1 < _width) list.Add(new Point { X = position.X + 1, Y = position.Y + 1 });
            if (position.Y - 1 >= 0) list.Add(new Point { X = position.X, Y = position.Y - 1 });
            if (position.Y + 1 < _width) list.Add(new Point { X = position.X, Y = position.Y + 1 });

            return list;
        }
    }
}
