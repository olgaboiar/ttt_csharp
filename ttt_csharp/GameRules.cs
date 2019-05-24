namespace ttt_csharp
{
    public class GameRules
    {
        public bool HorizontalWin(Board board)
        {
            return board.Spots[0].Equals(board.Spots[1]) & board.Spots[1].Equals(board.Spots[2])
                | board.Spots[3].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[5])
                | board.Spots[6].Equals(board.Spots[7]) & board.Spots[7].Equals(board.Spots[8]);
        }
        
        public bool VerticalWin(Board board)
        {
            return board.Spots[0].Equals(board.Spots[3]) & board.Spots[3].Equals(board.Spots[6])
                   | board.Spots[1].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[7])
                   | board.Spots[2].Equals(board.Spots[5]) & board.Spots[5].Equals(board.Spots[8]);
        }
        
        public bool DiagonalWin(Board board)
        {
            return board.Spots[0].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[8])
                   | board.Spots[2].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[6]);
        }
        
        public bool Win(Board board)
        {
            return HorizontalWin(board) | VerticalWin(board) | DiagonalWin(board);
        }
        
        public bool Tie(Board board)
        {
            return board.GetAvailableSpots().Count == 0;
        }
        
        public bool GameOver(Board board)
        {
            return Win(board) | Tie(board);
        }
    }
}