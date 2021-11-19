using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class ShipManager
    {
        public Ship CreateShip(string _shipType, int _size, int _hp)
        {
            Ship newShip = new Ship(_shipType, _size, _hp);

            return newShip;
        }
    }
}
