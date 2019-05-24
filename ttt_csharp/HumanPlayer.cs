namespace ttt_csharp
{
    public class HumanPlayer : IPlayer
    {
        private char _marker;
        private UserInterface _ui;
            
        public HumanPlayer(UserInterface ui, char humanMarker)
        {
            _marker = humanMarker;
            _ui = ui;
        }
        
        public void Move(Board board)
        {
            _ui.AskToMove();
            var move = _ui.ReadInput();
            board.SetSpot(move, _marker);
        }
        
        public char GetMarker()
        {
            return _marker;
        }
    }
}