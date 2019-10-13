using EscapeMines.Common.Interfaces.MinesGameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.MinesGameModels
{
    public class Turtle : Element, ITurtle
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation        
        /// There can be only one turtle
        /// </summary>
        private static Turtle _turtle;
        private Turtle(Point position)
        {
            Position = position;
        }
        public static Turtle Instance(Point position)
        {
            if (_turtle == null)
            {
                _turtle = new Turtle(position);
            }
            return _turtle;
        }
        #endregion

        public Directions Direction { get; set; }


        /// <summary>
        /// Rotate turtle to the left
        /// </summary>
        public void RotateLeft()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.West;                    
                    break;
                case Directions.South:
                    Direction = Directions.East;                    
                    break;
                case Directions.East:
                    Direction = Directions.North;                    
                    break;
                case Directions.West:
                    Direction = Directions.South;                    
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Rotate turtle to the right
        /// </summary>
        public void RotateRight()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;                    
                    break;
                case Directions.South:
                    Direction = Directions.West;                    
                    break;
                case Directions.East:
                    Direction = Directions.South;                    
                    break;
                case Directions.West:
                    Direction = Directions.North;                   
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Move by Point
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case Directions.North:                    
                    _turtle.Position = new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y };
                    break;

                case Directions.South:                    
                    _turtle.Position = new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y };
                    break;

                case Directions.East:                   
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 };
                    break;

                case Directions.West:                   
                    _turtle.Position = new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 };
                    break;
            }
        }               
    }
}
