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
            _testComp = new EasyComputer();
            _board = new Board();
        }
        
        [Test]
        public void MoveSetsORandomlyOnTheBoard()
        {
            _testComp.Move(_board);
            Assert.AreEqual(8, _board.GetAvailableSpots().Count);
            Assert.Contains('o', _board.Spots);
        }
    }
}