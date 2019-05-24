using System;

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
        private char humanMarker;
        private char computerMarker;
        
        public Game(UserInterface ui, Board board)
        {
            _ui = ui;
            Board = board;
            CurrentPlayer = null;
        }

        public void Initialize()
        {
            humanMarker = SetHumanMarker();
            human = new HumanPlayer(_ui, humanMarker);
            computerMarker = SetComputerMarker(humanMarker);
            computer = new EasyComputer(computerMarker);
            gameRules = new GameRules();
        }

        public char SetHumanMarker()
        {
            return _ui.SetHumanMarker();
        }

        public char SetComputerMarker(char humanMarker)
        {
            if (humanMarker == 'x')
            {
                return 'o';
            }

            return 'x';
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

        public void DeclareWinner()
        {
            if (!gameRules.Tie(Board))
            {
                var winner = CurrentPlayer.GetMarker();
                _ui.DeclareWinner(winner);
            }
            else
            {
                _ui.DeclareTie();
            }
            
        }
    }
}
