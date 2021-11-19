using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class ShipManager
    {
        public Ship CreateShip(string shipType, string abbreviation, int size, int hp)
        {
            Ship newShip = new Ship(shipType, abbreviation, size, hp);

            return newShip;
        }
    }
}
