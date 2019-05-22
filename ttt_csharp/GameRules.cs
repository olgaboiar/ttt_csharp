namespace ttt_csharp
{
    public class GameRules
    {
        public bool HorizontalWin(Board board, char marker)
        {
            return board.Spots[0].Equals(board.Spots[1]) & board.Spots[1].Equals(board.Spots[2]) & board.Spots[0].Equals(marker)
                | board.Spots[3].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[5]) & board.Spots[3].Equals(marker)
                | board.Spots[6].Equals(board.Spots[7]) & board.Spots[7].Equals(board.Spots[8]) & board.Spots[8].Equals(marker);
        }
        
        public bool VerticalWin(Board board, char marker)
        {
            return board.Spots[0].Equals(board.Spots[3]) & board.Spots[3].Equals(board.Spots[6]) & board.Spots[0].Equals(marker)
                   | board.Spots[1].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[7]) & board.Spots[4].Equals(marker)
                   | board.Spots[2].Equals(board.Spots[5]) & board.Spots[5].Equals(board.Spots[8]) & board.Spots[8].Equals(marker);
        }
        
        public bool DiagonalWin(Board board, char marker)
        {
            return board.Spots[0].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[8]) & board.Spots[0].Equals(marker)
                   | board.Spots[2].Equals(board.Spots[4]) & board.Spots[4].Equals(board.Spots[6]) & board.Spots[6].Equals(marker);
        }
        
        public bool Win(Board board, char marker)
        {
            return HorizontalWin(board, marker) | VerticalWin(board, marker) | DiagonalWin(board, marker);
        }
        
        public bool Tie(Board board)
        {
            return board.GetAvailableSpots().Count == 0;
        }
        
        public bool GameOver(Board board, char marker)
        {
            return Win(board, marker) | Tie(board);
        }
    }
}