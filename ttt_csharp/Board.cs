using System;
using System.Collections.Generic;
using System.Linq;

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
                if (IsAvailableSpot(spot)) availableSpots.Add(spot);
            }
            return availableSpots;
        }

        public string PrepareForPrint()
        {
            return String.Format("\n          {0} | {1} | {2}\n         -----------\n" +
                                 "          {3} | {4} | {5}\n         -----------\n" +
                                 "          {6} | {7} | {8}\n        \n", Spots.Select(x=>x.ToString()).ToArray());
        }

        public bool IsAvailableSpot(object spot)
        {
            return spot is int;
        }
    }
}