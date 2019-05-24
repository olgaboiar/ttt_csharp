namespace ttt_csharp
{
    public class MediumComputer : Computer
    {
        private int _move;
        public MediumComputer(char marker) : base(marker)
        {
//            _marker = marker;
        }

        public void Move(Board board)
        {
            if (board.Spots[4].Equals(5))
            {
                _move = 5;
            }
            else
            {
                _move = RandomMove(board);   
            }
            
            board.SetSpot(_move, _marker);
        }
    }
}