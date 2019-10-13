using EscapeMines.Common.Inerfaces.Operations;
using EscapeMines.Common.Interfaces.MinesGameModels;
using EscapeMines.Common.Interfaces.ReadModels;
using EscapeMines.Common.MinesGameModels;
using EscapeMines.Common.Operations;
using EscapeMines.Common.ReadModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    /// <summary>
    /// Test the situation where we expect that the turtle will die :( (Result: Mine hit)
    /// </summary>
    [TestFixture]
    public class TestIsDeadTurtle
    {
        private IReadSettingsModel _readSettingsModel;
        private IFileRead fileRead;
        private IGrid grid;
        private IGame game;
        

        [SetUp]
        public void SetUp()
        {           
            _readSettingsModel = new ReadSettingsModel();
            _readSettingsModel.MinePoints.Add(new Point(1, 1));
            _readSettingsModel.MinePoints.Add(new Point(1, 3));
            _readSettingsModel.MinePoints.Add(new Point(3, 3));
            _readSettingsModel.Size = new Point(5, 4);
            _readSettingsModel.Direction = "N";
            _readSettingsModel.StartPoint = new Point(1, 0);
            _readSettingsModel.Moves = new string[] { "R", "M", "L", "M", "M", "R", "M", "M", "M" };
            
            _readSettingsModel.ExitPoint = new Point(2, 4);                           
        }

        [Test]
        public void Run()
        {
            grid = new Grid(5, 5);
            game = new EscapeMines.Common.MinesGameModels.Game(null, null, _readSettingsModel);
            var result = game.Start();
            Assert.AreEqual(State.IsDead, result);
        }

        [TearDown]
        public void Dispose()
        {
            _readSettingsModel = null;
            fileRead = null;
            grid = null;
            game = null;
        }
    
    }
}
