using EscapeMines.Common.Inerfaces.Operations;
using EscapeMines.Common.MinesGameModels;
using EscapeMines.Common.ReadModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EscapeMines.Common.Operations
{
    public class FileRead : IFileRead
    {
        private static IFileRead _fileReader;

        public FileRead()
        {
        }

        /// <summary>
        /// File reader 
        /// singleton pattern
        /// </summary>
        public static IFileRead Instance()
        {
            if (_fileReader == null)
            {
                _fileReader = new FileRead();
            }
            return _fileReader;
        }

        private Point GetPoint(string x, string y)
        {
            try
            {
                var X = int.Parse(x);
                var Y = int.Parse(y);

                return new Point(X, Y);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReadSettingsModel GetGameSettings()
        {
            try
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                var settingsPath = Path.Combine(path, @"GameSettings\Settings.txt");
                var settingString = File.ReadAllLines(settingsPath);
                var settings = new ReadSettingsModel();

                //BoardSize
                var sizeString = settingString[0].Split(null);              
                settings.Size = GetPoint(sizeString[0], sizeString[1]);

                //Mine points
                var mineString = settingString[1].Split(null);
                foreach (var mineCoordinates in from mine in mineString
                                                let twomines = mine.Split(",")
                                                select twomines)
                {
                    if (string.IsNullOrEmpty(mineCoordinates[0]) || string.IsNullOrEmpty(mineCoordinates[1]))
                        continue;
                    settings.MinePoints.Add(GetPoint(mineCoordinates[0], mineCoordinates[1]));
                }

                //Exit point
                var exitPointStrings = settingString[2].Split(null);
                settings.ExitPoint = GetPoint(exitPointStrings[0], exitPointStrings[1]);

                //Start point with direction
                var startPositionStrings = settingString[3].Split(null);
                settings.StartPoint = GetPoint(startPositionStrings[0], startPositionStrings[1]);
                settings.Direction = startPositionStrings[2];

                //Set of moves
                List<string> moves = new List<string>();
                for (int i = 4; i < settingString.Length; i++)
                {
                    moves.Add(settingString[i]);
                }

                var allMoves = string.Join(null, moves).Split(null);
                settings.Moves = allMoves.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                return settings;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error reading game settings");
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }          
        }       
    }
}

