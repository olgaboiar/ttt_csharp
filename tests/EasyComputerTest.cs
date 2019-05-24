using System;
using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture()]
    public class EasyComputerTest
    {
        private EasyComputer _testComp;
        private Board _board;
        
        [SetUp]
        public void Setup()
        {
            _testComp = new EasyComputer('o');
            _board = new Board();
        }
        
        [Test]
        public void MoveSetsORandomlyOnTheBoard()
        {
            _testComp.Move(_board);
            Assert.AreEqual(8, _board.GetAvailableSpots().Count);
            Assert.Contains('o', _board.Spots);
        }

        [Test]
        public void RandomMoveReturnsMoveInPossibleMovesRange()
        {
            Assert.IsInstanceOf(typeof(Int32),_testComp.RandomMove(_board));
            
            _board.SetSpot(1, 'x');
            _board.SetSpot(2, 'o');
            _board.SetSpot(3, 'x');
            
            Assert.GreaterOrEqual(_testComp.RandomMove(_board), 4);
            Assert.LessOrEqual(_testComp.RandomMove(_board), 9);
        }
        
        [Test]
        public void GetMarkerReturnsCompMarker()
        {
            var actual = _testComp.GetMarker();
            Assert.AreEqual('o', actual);
        }
    }
}