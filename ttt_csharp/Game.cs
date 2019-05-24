using System;

namespace ttt_csharp
{
    public class Game
    {
        private UserInterface _ui;
        public Board Board;
        private HumanPlayer human;
        private Computer computer;
        public IPlayer CurrentPlayer;
        private GameRules gameRules;
        private char humanMarker;
        private char computerMarker;
        private int difficultyLevel;
        
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
            difficultyLevel = SetDifficultyLevel();
            computer = SetComputer(computerMarker, difficultyLevel);
            gameRules = new GameRules();
        }

        public Computer SetComputer(char computerMarker, int difficultyLevel)
        {
            if (difficultyLevel == 1)
            {
                return new EasyComputer(computerMarker);
            }
            return new MediumComputer(computerMarker);
        }
        public int SetDifficultyLevel()
        {
            return _ui.GetDifficultyLevel();
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
                CurrentPlayer = SetFirstPlayer();
            }
            else
            {
                CurrentPlayer = ChangePlayers(CurrentPlayer);
            }
        }

        public IPlayer SetFirstPlayer()
        {
            if (human.GetMarker() == 'x')
            {
                return human;
            }

            return computer;
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
