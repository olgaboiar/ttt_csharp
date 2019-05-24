using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class GameTest
    {
        private Game _testGame;
        private ConsoleMock _consoleMock;
        private UserInterface _ui;
        private GameRules _testGameRules;
        private Board _testBoard;
        
        [SetUp]
        public void SetUp()
        {
            _consoleMock = new ConsoleMock();
            _ui = new UserInterface(_consoleMock);
            _testBoard = new Board();
            _testGame = new Game(_ui, _testBoard);
            _testGameRules = new GameRules();
        }

        [Test]
        public void BoardIsInGameOverStateAfterPlayRuns()
        {
            Assert.False(_testGameRules.GameOver(_testGame.Board));
            
            _testGame.Initialize();
            _testGame.Play();
            
            Assert.True(_testGameRules.GameOver(_testGame.Board));
        }
        
        [Test]
        public void PlayCallsPrintsOutputAtLeastNineTimes()
        {
            _testGame.Initialize();
            _testGame.Play();
            Assert.GreaterOrEqual(_consoleMock.numTimesOutputCalled, 9);
        }
        
        [Test]
        public void PlayCallsReadInputAtLeastThreeTimes()
        {
            _testGame.Initialize();
            _testGame.Play();
            Assert.GreaterOrEqual(_consoleMock.numTimesReadInputCalled, 3);
        }
        
        [Test]
        public void SetsCurrentPlayerToHumanIfCurrentPlayerIsNotSet()
        {
            _testGame.Initialize();
            _testGame.SetCurrentPlayer();
            Assert.IsInstanceOf(typeof(HumanPlayer), _testGame.CurrentPlayer);
        }

        [Test]
        public void SetsCurrentPlayerToComputerIfCurrentPlayerIsHuman()
        {
            _testGame.Initialize();
            _testGame.SetCurrentPlayer();
            _testGame.SetCurrentPlayer();
            Assert.IsInstanceOf(typeof(EasyComputer), _testGame.CurrentPlayer);
        }

        [Test]
        public void SetsCurrentPlayerToHumanIfCurrentPlayerIsComputer()
        {
            _testGame.Initialize();
            _testGame.SetCurrentPlayer();
            _testGame.SetCurrentPlayer();
            _testGame.SetCurrentPlayer();
            Assert.IsInstanceOf(typeof(HumanPlayer), _testGame.CurrentPlayer);
        }
        
        [Test]
        public void ReturnsComputerIfCurrentPlayerIsHuman()
        {
            _testGame.Initialize();
            _testGame.SetCurrentPlayer();
            var actual = _testGame.ChangePlayers(_testGame.CurrentPlayer);
            Assert.IsInstanceOf(typeof(EasyComputer), actual);
        }

        [Test]
        public void ReturnsHumanIfCurrentPlayerIsComputer()
        {
            _testGame.Initialize();
            _testGame.SetCurrentPlayer();
            _testGame.SetCurrentPlayer();
            var actual = _testGame.ChangePlayers(_testGame.CurrentPlayer);
            Assert.IsInstanceOf(typeof(HumanPlayer), actual);
        }
    }
}