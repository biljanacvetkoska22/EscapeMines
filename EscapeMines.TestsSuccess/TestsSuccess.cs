using EscapeMines.Common.Inerfaces.Operations;
using EscapeMines.Common.Interfaces.MinesGameModels;
using EscapeMines.Common.Interfaces.ReadModels;
using EscapeMines.Common.MinesGameModels;
using EscapeMines.Common.ReadModels;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test the situation where we expect that the turtle will exit :) (Result: Success)
    /// </summary>
    public class TestsSuccess
    {        
        [TestFixture]
        class TestSuccess
        {
            private IReadSettingsModel _readSettingsModel = null;
            private IFileRead fileRead = null;
            private IGrid grid = null;
            private IGame game = null;
           
            [SetUp]
            public void SetUp()
            {
                _readSettingsModel = new ReadSettingsModel();
                _readSettingsModel.MinePoints.Add(new Point(1, 1));
                _readSettingsModel.MinePoints.Add(new Point(2, 0));
                _readSettingsModel.Size = new Point(5, 5);
                _readSettingsModel.Direction = "N";
                _readSettingsModel.StartPoint = new Point(1, 0);
                _readSettingsModel.Moves = new string[] { "M", "R", "M", "M", "M", "M" };
                _readSettingsModel.ExitPoint = new Point(0, 4);
            }
           
            [Test]
            public void Run()
            {
                grid = new Grid(5, 5);

                game = new EscapeMines.Common.MinesGameModels.Game(null, null, _readSettingsModel);

                var result = game.Start();
                Assert.AreEqual(State.IsExit, result);
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
}