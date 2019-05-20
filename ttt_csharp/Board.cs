using System.Collections.Generic;

namespace ttt_csharp
{
    public class Board
    {
        public List<object> Spots;
        public Board()
        {
            Spots = new List<object>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        }

        public object GetSpot(int spot)
        {
            return Spots[spot - 1];
        }

        public void SetSpot(int spot, char marker)
        {
            Spots[spot - 1] = marker;
        }

        public List<object> GetAvailableSpots()
        {
            List<object> availableSpots = new List<object>();
            foreach (var spot in Spots)
            {
                if (spot is int)
                {
                    availableSpots.Add(spot);
                }
            }
            return availableSpots;
        }
    }
}