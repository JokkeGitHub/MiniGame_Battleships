using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class GridManager
    {
        public Grid CreatePosition(string position, bool isOccupied, bool isHit)
        {
            Grid newGrid = new Grid(position, isOccupied, isHit);

            return newGrid;
        }
    }
}
