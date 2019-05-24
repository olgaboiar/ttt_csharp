using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class HumanPlayerTest
    {
        private UserInterface _ui;
        private HumanPlayer _testHuman;
        private Board _board;
        private ConsoleMock _consoleMock;
        
        [SetUp]
        public void Setup()
        {
            _consoleMock = new ConsoleMock();
            _ui = new UserInterface(_consoleMock);
            _testHuman = new HumanPlayer(_ui, 'x');
            _board = new Board();
        }
        
        [Test]
        public void MoveSetsXOnTheBoard()
        {
            _testHuman.Move(_board);
            Assert.AreEqual('x', _board.Spots[4]);
        }
        
        [Test]
        public void MoveIsCalledWithUiReadAndOutputMethods()
        {
            _testHuman.Move(_board);
            Assert.AreEqual(1, _consoleMock.numTimesOutputCalled);
            Assert.AreEqual(1, _consoleMock.numTimesReadInputCalled);
        }
        
        [Test]
        public void GetMarkerReturnsCompMarker()
        {
            var actual = _testHuman.GetMarker();
            Assert.AreEqual('x', actual);
        }
    }
}