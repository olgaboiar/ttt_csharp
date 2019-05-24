using NUnit.Framework;
using ttt_csharp;

namespace tests
{
    [TestFixture]
    public class GameRulesTest
    {
        private Board _board;
        private Board _tieBoard;
        private GameRules _gameRules;
        private char _xMarker = 'x';
        private char _oMarker = 'o';
        
        [SetUp]
        public void Setup()
        {
            _board = new Board();
            _gameRules = new GameRules();
            _tieBoard = new Board();
            _tieBoard.SetSpot(1, _xMarker);
            _tieBoard.SetSpot(2, _oMarker);
            _tieBoard.SetSpot(3, _xMarker);
            _tieBoard.SetSpot(4, _xMarker);
            _tieBoard.SetSpot(5, _oMarker);
            _tieBoard.SetSpot(6, _oMarker);
            _tieBoard.SetSpot(7, _oMarker);
            _tieBoard.SetSpot(8, _xMarker);
            _tieBoard.SetSpot(9, _xMarker);
        }

        [Test]
        public void ReturnsTrueForHorizontalWinWhenFirstRowIsX()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _xMarker);
            Assert.True(_gameRules.HorizontalWin(_board));
        }
        
        [Test]
        public void ReturnsTrueForHorizontalWinWhenSecondRowIsO()
        {
            _board.SetSpot(4, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(6, _oMarker);
            Assert.True(_gameRules.HorizontalWin(_board));
        }
        
        [Test]
        public void ReturnsTrueForHorizontalWinWhenThirdRowIsO()
        {
            _board.SetSpot(7, _oMarker);
            _board.SetSpot(8, _oMarker);
            _board.SetSpot(9, _oMarker);
            Assert.True(_gameRules.HorizontalWin(_board));
        }
        
        [Test]
        public void ReturnsFalseForHorizontalWinWhenBoardIsEmptyOrTie()
        {
            Assert.False(_gameRules.HorizontalWin(_board)); 
            Assert.False(_gameRules.HorizontalWin(_tieBoard));
        }
        
        [Test]
        public void ReturnsTrueForVerticalWinWhenFirstColumnIsX()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(4, _xMarker);
            _board.SetSpot(7, _xMarker);
            Assert.True(_gameRules.VerticalWin(_board));
        }
        
        [Test]
        public void ReturnsTrueForVerticalWinWhenSecondColumnIsO()
        {
            _board.SetSpot(2, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(8, _oMarker);
            Assert.True(_gameRules.VerticalWin(_board));
        }
        
        [Test]
        public void ReturnsTrueForVerticalWinWhenThirdColumnIsO()
        {
            _board.SetSpot(3, _oMarker);
            _board.SetSpot(6, _oMarker);
            _board.SetSpot(9, _oMarker);
            Assert.True(_gameRules.VerticalWin(_board));
        }
        
        [Test]
        public void ReturnsFalseForVerticalWinWhenBoardIsEmptyOrTie()
        {
            Assert.False(_gameRules.VerticalWin(_board)); 
            Assert.False(_gameRules.VerticalWin(_tieBoard));
        }
        
        [Test]
        public void ReturnsTrueForDiagonalWinWhenFirstDiagonalIsO()
        {
            _board.SetSpot(1, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(9, _oMarker);
            Assert.True(_gameRules.DiagonalWin(_board));
        }
        
        [Test]
        public void ReturnsTrueForDiagonalWinWhenSecondDiagonalIsX()
        {
            _board.SetSpot(3, _xMarker);
            _board.SetSpot(5, _xMarker);
            _board.SetSpot(7, _xMarker);
            Assert.True(_gameRules.DiagonalWin(_board));
        }
        
        [Test]
        public void ReturnsFalseForDiagonalWinWhenBoardIsEmptyOrTie()
        {
            Assert.False(_gameRules.DiagonalWin(_board)); 
            Assert.False(_gameRules.DiagonalWin(_tieBoard));
        }
        
        [Test]
        public void ReturnsTrueForWinWhenFirstRowIsX()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _xMarker);
            Assert.True(_gameRules.Win(_board));
        }
        
        [Test]
        public void ReturnsTrueForWinWhenThirdColumnIsO()
        {
            _board.SetSpot(3, _oMarker);
            _board.SetSpot(6, _oMarker);
            _board.SetSpot(9, _oMarker);
            Assert.True(_gameRules.Win(_board));
        }
        
        [Test]
        public void ReturnsTrueForWinWhenSecondDiagonalIsX()
        {
            _board.SetSpot(3, _xMarker);
            _board.SetSpot(5, _xMarker);
            _board.SetSpot(7, _xMarker);
            Assert.True(_gameRules.Win(_board));
        }
        
        [Test]
        public void ReturnsFalseForWinWhenBoardIsEmptyOrTie()
        {
            Assert.False(_gameRules.Win(_board)); 
            Assert.False(_gameRules.Win(_tieBoard));
        }

        [Test]
        public void ReturnsFalseForWinWhenBoardIsNotEmptyButNotCompletelyFull()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(6, _oMarker);
            _board.SetSpot(9, _xMarker);
            
            Assert.False(_gameRules.Win(_board));
        }
        
        [Test]
        public void ReturnsTrueForTieWhenBoardIsTie()
        {
            Assert.True(_gameRules.Tie(_tieBoard));
        }
        
        [Test]
        public void ReturnsFalseForTieWhenBoardIsEmpty()
        {
            Assert.False(_gameRules.Tie(_board));
        }
        
        [Test]
        public void ReturnsFalseForTieWhenBoardIsNotEmptyButNotCompletelyFull()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(6, _oMarker);
            _board.SetSpot(9, _xMarker);
            
            Assert.False(_gameRules.Tie(_board));
        }
        
        [Test]
        public void ReturnsTrueForGameOverWhenFirstRowIsX()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _xMarker);
            Assert.True(_gameRules.GameOver(_board));
        }
        
        [Test]
        public void ReturnsTrueForGameOverWhenBoardIsTie()
        {
            Assert.True(_gameRules.GameOver(_tieBoard));
        }
        
        [Test]
        public void ReturnsFalseForGameOverWhenBoardIsEmpty()
        {
            Assert.False(_gameRules.GameOver(_board)); 
        }
        
        [Test]
        public void ReturnsFalseForGameOverWhenBoardIsNotEmptyButNotCompletelyFull()
        {
            _board.SetSpot(1, _xMarker);
            _board.SetSpot(2, _xMarker);
            _board.SetSpot(3, _oMarker);
            _board.SetSpot(5, _oMarker);
            _board.SetSpot(6, _oMarker);
            _board.SetSpot(9, _xMarker);
            
            Assert.False(_gameRules.GameOver(_board));
        }
    }
}