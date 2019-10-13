using EscapeMines.Common.Inerfaces.Operations;
using EscapeMines.Common.Interfaces.MinesGameModels;
using EscapeMines.Common.Interfaces.ReadModels;
using EscapeMines.Common.MinesGameModels;
using EscapeMines.Common.Operations;
using EscapeMines.Common.ReadModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace EscapeMinesUnitTest
{
    [TestFixture]
    public class EscapeMinesUnitTest
    {

        [Test]
        public void TestPoint()
        {
            Point point = new Point(10, 5);
            Assert.AreEqual(5, point.Y);
        }

        [Test]
        public void TestObserver()
        {
            IObserver observer = new Observer(new Grid(10, 6));
            Assert.AreEqual(false, observer.IsDanger(new Point(5, 5)));
        }           
    }
}