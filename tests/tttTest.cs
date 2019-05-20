using System;
using System.Collections.Generic;
using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class BoardTest
    {
        private Board _board;
        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }
        [Test]
        public void Creation()
        {
            Assert.AreEqual(9, _board.Spots.Count);
        }

        [Test]
        public void ReturnsValueOfTheSpot()
        {
            var actual = _board.GetSpot(2);
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void AssignsSpotValue()
        {
            _board.SetSpot(2, 'x');
            var actual = _board.Spots[1];
            Assert.AreEqual('x', actual);
        }

        [Test]
        public void ReturnsListOfAvailableSpots()
        {
            _board.SetSpot(4, 'o');
            var actual = _board.GetAvailableSpots();
            Assert.AreEqual(8, actual.Count);
            Assert.AreEqual(new List<object>() {1,2,3,5,6,7,8,9}, actual);
        }
    }
}
