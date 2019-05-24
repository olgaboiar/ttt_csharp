using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class MediumComputerTest
    {
        private MediumComputer _testComp;
        private Board _board;
        
        [SetUp]
        public void Setup()
        {
            _testComp = new MediumComputer('o');
            _board = new Board();
        }

        [Test]
        public void ItMovesOnFive()
        {
            _testComp.Move(_board);
            Assert.AreEqual('o',_board.Spots[4]);
        }
    }
}