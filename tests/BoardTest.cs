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
            _board.SetSpot(3, 'x');
            _board.SetSpot(4, 'o');
            
            Assert.AreEqual(2,_board.GetSpot(2));
            Assert.AreEqual('x',_board.GetSpot(3));
            Assert.AreEqual('o',_board.GetSpot(4));
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
            Assert.AreEqual(9, _board.GetAvailableSpots().Count);
            
            _board.SetSpot(4, 'o');
            
            Assert.AreEqual(8, _board.GetAvailableSpots().Count);
            Assert.AreEqual(new List<object>() {1,2,3,5,6,7,8,9}, _board.GetAvailableSpots());
        }
    }
}
