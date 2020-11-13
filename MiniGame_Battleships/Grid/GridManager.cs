namespace MiniGame_Battleships
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
