using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public abstract class Competitor
    {
        public List<Ship> Ships { get; set; }
        public List<Ship> PlacedShips { get; set; }

        public List<Ship> GetShipList()
        {
            ShipManager shipManager = new ShipManager();
            List<Ship> ships = new List<Ship>();
            ships = shipManager.CreateAllShips();
            return ships;
        }

        public abstract bool VerticalOrHorizontalPlacement(bool vertical);
        public abstract Grid PositionPlacement(Grid grid, Ship ship);
        public abstract bool CheckPositionAvailability(Grid grid, int positionY, int positionX, bool shipVertical, int shipSize, bool allPositionsAvailable);
        public abstract bool CheckVerticalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable);
        public abstract bool CheckHorizontalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable);
        public abstract Grid PlaceShip(Grid grid, Ship ship, int positionY, int positionX);
    }
}
