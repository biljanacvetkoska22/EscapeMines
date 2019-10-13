using EscapeMines.Common.Inerfaces.Operations;
using EscapeMines.Common.Interfaces.MinesGameModels;
using EscapeMines.Common.Interfaces.Operations;
using EscapeMines.Common.Interfaces.ReadModels;
using EscapeMines.Common.Operations;
using EscapeMines.Common.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EscapeMines.Common.MinesGameModels
{
    /// <summary>
    /// In the implementation of factory pattern we use interfaces for 
    /// making the classes loosely  coupled. 
    /// Dependency inversion principle from SOLID principles
    /// </summary>
    public class Game : IGame, IDisposable
    {
        private Point _turtleStartPoint;
        private IFileRead _fileReader;
        private IValidateSettings _validateSettings;
        private IReadSettingsModel _gameSettings;        

        private IGrid _grid;
        private IObserver _observer;

        #region Factory pattern

        /// <summary>
        /// Factory pattern implementation 
        /// </summary>
        private Game()
        {
            _fileReader = FileRead.Instance();
            _gameSettings = _fileReader.GetGameSettings();
            _validateSettings = new ValidateSettings(_gameSettings);
            _turtleStartPoint = _gameSettings.StartPoint;
            _grid = new Grid(_gameSettings.Size.Y, _gameSettings.Size.X);
            _observer = new Observer(_grid);
            Initialize();
        }

        public Game(IFileRead fileRead, IValidateSettings validateSettings, IReadSettingsModel settings)
        {
            _fileReader = fileRead;
            _gameSettings = settings;
            _validateSettings = validateSettings;
            _turtleStartPoint = _gameSettings.StartPoint;
            _grid = new Grid(_gameSettings.Size.Y, _gameSettings.Size.X);
            _observer = new Observer(_grid);
            Initialize();
        }        

        public static IGame CreateNewGame()
        {
            return new Game();
        }
        #endregion

        /// <summary>
        /// Validate game input settings
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
           return _validateSettings.ValidateInputSettings();
        }

        /// <summary>
        /// Start game from start position
        /// </summary>
        public State Start()
        {
            var printer = new Print();
            var moves = _gameSettings.Moves;
            var turtle = _grid[_turtleStartPoint] as Turtle;
            if (System.Enum.TryParse<Directions>(_gameSettings.Direction, out var dir)) turtle.Direction = dir;
            //Printer.Print(turtle);
            State situation = State.Normal;
            for (int i = 0; i < moves.Length; i++)
            {
                if (string.Equals(moves[i], "r", StringComparison.CurrentCultureIgnoreCase)) turtle.RotateRight();
                if (string.Equals(moves[i], "l", StringComparison.CurrentCultureIgnoreCase)) turtle.RotateLeft();
                if (string.Equals(moves[i], "m", StringComparison.CurrentCultureIgnoreCase)) turtle.Move();
                Thread.Sleep(1000);
                situation = _observer.Observe(turtle.Position);
                if (situation == State.IsDead)
                {
                    printer.PrintResult(situation);
                    return situation;
                }
                else if (situation == State.IsExit)
                {
                    printer.PrintResult(situation);
                    return situation;
                }
                else if (situation == State.IsOutOfBounds)
                {
                    printer.PrintResult(situation);
                    return situation;
                }                
            }

            
            printer.PrintResult(situation);

            return situation;
        }

        private void Initialize()
        {
            SetTurtle(_turtleStartPoint);
            SetExit(_gameSettings.ExitPoint);
            SetMines(_gameSettings.MinePoints);
        }


        /// <summary>
        /// Setting mines in the grid
        /// </summary>
        /// <param name="mines"></param>
        private void SetMines(List<Point> mines)
        {
            foreach (var minePosition in mines)
            {
                try
                {
                    _grid[minePosition] = new Mine() { Position = minePosition };
                }
                catch
                {/*ignore*/ }
            }
        }

        /// <summary>
        /// Setting exit point in the grid
        /// </summary>
        /// <param name="exitPosition"></param>
        private void SetExit(Point exitPosition)
        {
            try
            {
                _grid[exitPosition] = new Exit() { Position = exitPosition };
            }
            catch
            {/*ignore*/}
        }


        /// <summary>
        /// Setting turtle in the grid
        /// </summary>
        /// <param name="turtlePosition"></param>
        private void SetTurtle(Point turtlePosition)
        {
            try
            {
                _grid[turtlePosition] = Turtle.Instance(turtlePosition);
            }
            catch
            {/*ignore*/}
        }

        /// <summary>
        /// Dispose after all of the operations are complete
        /// </summary>
        public void Dispose()
        {
            _fileReader = null;
            _gameSettings = null;
            _validateSettings = null;            
            _grid = null;
            _observer = null;
        }
    }
}
