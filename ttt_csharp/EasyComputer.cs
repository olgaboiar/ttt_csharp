using System;
using System.Collections.Generic;

namespace ttt_csharp
{
    public class EasyComputer : IPlayer
    {
        private char _marker;
        const char oMarker = 'o';

        public EasyComputer()
        {
            _marker = oMarker;
        }
        public void Move(Board board)
        {
            var move = RandomMove(board);
            board.SetSpot(move, _marker);
        }

        private int RandomMove(Board board)
        {
            List<object> possibleMoves = board.GetAvailableSpots();
            Random rand = new Random();
            int index = rand.Next(possibleMoves.Count);
            return Convert.ToInt32(possibleMoves[index]);
        }

        public char GetMarker()
        {
            return _marker;
        }
    }
}