using System;

namespace ttt_csharp
{
    public class UserInterface
    {
        private IUserInterface _ui;
        public UserInterface(IUserInterface ui)
        {
            _ui = ui;
        }

        public void Greet()
        {
            var greeting = "Hello! Lets play TicTacToe";
            _ui.Output(greeting);
        }
        
        public void AskToMove()
        {
            _ui.Output("Input a number to make your move");
        }

        public void PrintBoard(Board board)
        {
            var stringBoard = board.PrepareForPrint();
            _ui.Output(stringBoard);
        }

        public int ReadInput()
        {
            string input = _ui.ReadInput();
            return Convert.ToInt32(input);
        }

        public void DeclareTie()
        {
            String tieMessage = "Game Over! It's a tie!";
            _ui.Output(tieMessage);
        }

        public void DeclareWinner(char winner)
        {
            String winnerMessage = "Game Over! The winner is " + winner;
            _ui.Output(winnerMessage);
        }
        
    }
}