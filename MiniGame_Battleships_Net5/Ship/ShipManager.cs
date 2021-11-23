using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class ShipManager
    {
        private Ship CreateShip(string shipType, string abbreviation, int size, int hp)
        {
            Ship newShip = new Ship(shipType, abbreviation, size, hp);

            return newShip;
        }

        #region Ship Types
        private Ship CreateHangarShip()
        {
            Ship hangarShip = CreateShip("Hangar Ship", "HS", 5, 5);

            return hangarShip;
        }

        private Ship CreateBattleship()
        {
            Ship battleship = CreateShip("Battleship", "BS", 4, 4);

            return battleship;
        }

        private Ship CreateDestroyer()
        {
            Ship destroyer = CreateShip("Destroyer", "DS", 3, 3);

            return destroyer;
        }

        private Ship CreateSubmarine()
        {
            Ship Submarine = CreateShip("Submarine", "SM", 3, 3);

            return Submarine;
        }

        private Ship CreatePatrolBoat()
        {
            Ship patrolBoat = CreateShip("Patrol Boat", "PB", 2, 2);

            return patrolBoat;
        }
        #endregion

        public List<Ship> CreateAllShips()
        {
            List<Ship> ships = new List<Ship>();

            Ship hangarShip = CreateHangarShip();
            Ship battleship = CreateBattleship();
            Ship destroyer = CreateDestroyer();
            Ship submarine = CreateSubmarine();
            Ship patrolBoat = CreatePatrolBoat();

            ships.Add(hangarShip);
            ships.Add(battleship);
            ships.Add(destroyer);
            ships.Add(submarine);
            ships.Add(patrolBoat);

            return ships;
        }
    }
}
