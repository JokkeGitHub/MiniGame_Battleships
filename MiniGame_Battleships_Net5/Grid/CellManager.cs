using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class CellManager
    {
        public Cell CreatePosition(string position, bool isOccupied, bool isHit)
        {
            Cell newCell = new Cell(position, isOccupied, isHit);

            return newCell;
        }
    }
}
