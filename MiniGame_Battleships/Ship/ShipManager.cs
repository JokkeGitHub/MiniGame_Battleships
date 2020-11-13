namespace MiniGame_Battleships
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
