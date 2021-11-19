using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships.Net5._0.Ship
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
