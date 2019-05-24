namespace ttt_csharp
{
    public class HumanPlayer : IPlayer
    {
        private char _marker;
        const char xMarker = 'x';
        private UserInterface _ui;
            
        public HumanPlayer(UserInterface ui)
        {
            _marker = xMarker;
            _ui = ui;
        }
        
        public void Move(Board board)
        {
            _ui.AskToMove();
            var move = _ui.ReadInput();
            board.SetSpot(move, _marker);
        }
    }
}