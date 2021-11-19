using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class GridManager
    {
        public Grid CreatePosition(string _position, bool _isOccupied, bool _isHit)
        {
            Grid newGrid = new Grid(_position, _isOccupied, _isHit);

            return newGrid;
        }
    }
}
