using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class Grid
    {
        public string Position { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsHit { get; set; }

        public Grid(string position, bool isOccupied, bool isHit)
        {
            Position = position;
            IsOccupied = isOccupied;
            IsHit = isHit;
        }
    }
}
