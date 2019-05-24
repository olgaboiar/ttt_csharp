namespace ttt_csharp
{
    public class Game
    {
        private UserInterface _ui;
        public Board Board;
        private HumanPlayer human;
        private EasyComputer computer;
        public IPlayer CurrentPlayer;
        private GameRules gameRules;
        
        public Game(UserInterface ui, Board board)
        {
            _ui = ui;
            Board = board;
            CurrentPlayer = null;
        }

        public void Initialize()
        {
            human = new HumanPlayer(_ui);
            computer = new EasyComputer();
            gameRules = new GameRules();
        }

        public void Play()
        {
            _ui.PrintBoard(Board);
            while (!gameRules.GameOver(Board))
            {
                SetCurrentPlayer();
                CurrentPlayer.Move(Board);
                _ui.PrintBoard(Board);
            }
        }

        public void SetCurrentPlayer()
        {
            if (CurrentPlayer == null)
            {
                CurrentPlayer = human;
            }
            else
            {
                CurrentPlayer = ChangePlayers(CurrentPlayer);
            }
        }

        public IPlayer ChangePlayers(IPlayer currentPlayer)
        {
            if (currentPlayer == human)
            {
                return computer;
            }

            return human;
        }
    }
}