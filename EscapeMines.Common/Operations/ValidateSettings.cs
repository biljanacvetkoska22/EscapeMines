using EscapeMines.Common.Interfaces.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EscapeMines.Common.MinesGameModels;
using EscapeMines.Common.Interfaces.Operations;

namespace EscapeMines.Common.Operations
{
    public class ValidateSettings : IValidateSettings
    {
        private IReadSettingsModel _readSettingsModel;

        public ValidateSettings()
        {

        }
        public ValidateSettings(IReadSettingsModel readSettingsModel)
        {
            _readSettingsModel = readSettingsModel;
        }

        /// <summary>
        /// Validate game input settings
        /// </summary>
        /// <returns></returns>
        public bool ValidateInputSettings()
        {
            if (!ValidateStartPointSettings(_readSettingsModel.StartPoint, _readSettingsModel.Size))
            {
                Console.WriteLine("Settings error: Turtle is out of range");
                return false;
            }

            if (!ValidatePointRangeSettings(_readSettingsModel.ExitPoint))
            {
                Console.WriteLine("Settings error: Exit point is out of range");
                return false;
            }

            if(!ValidateTurtleDirection(_readSettingsModel.Direction))
            {
                Console.WriteLine("Invalid turtle direction input");
                return false;
            }

            if(!ValidateTurtleMoves(_readSettingsModel.Moves))
            {
                Console.WriteLine("Invalid turtle moves in settings");
                return false;
            }

            foreach (var point in _readSettingsModel.MinePoints)
            {
                if (!ValidatePointRangeSettings(point))
                {
                    Console.WriteLine("Settings error: Invalid point setting for mine points");                    
                    return false;
                }
            }
            
            return true;
        }

        public bool ValidateStartPointSettings(Point startPoint, Point size)
        {
            return startPoint.X < size.X && startPoint.Y < size.Y && startPoint.X >= 0 && startPoint.Y >= 0;
        }

        public bool ValidatePointRangeSettings(Point point)
        {
            return point.X >= 0 && point.Y >= 0;
        }

        public bool ValidateTurtleDirection(string direction)
        {
            string[] stringArray = new string[] { "n", "e", "s", "w", "N", "E", "S", "W"};
            return stringArray.Contains(direction);            
        }

        public bool ValidateTurtleMoves(string[] moves)
        {
            string[] stringArray = new string[] { "r", "l", "m", "R", "L", "M" };
            foreach(var move in moves)
            {
                if (!stringArray.Contains(move))
                    return false;
            }
            return true;
        }
    }
}

