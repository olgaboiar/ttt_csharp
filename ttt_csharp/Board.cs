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
    }
}