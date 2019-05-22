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

        public void PrintBoard(Board board)
        {
            var stringBoard = board.PrepareForPrint();
            _ui.Output(stringBoard);
        }
    }
}