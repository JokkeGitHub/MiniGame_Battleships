namespace MiniGame_Battleships
{
    class Grid
    {
        private string _position;
        private bool _isOccupied;
        private bool _isHit;

        public string Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return this._isOccupied;
            }
            set
            {
                this._isOccupied = value;
            }
        }

        public bool IsHit
        {
            get
            {
                return this._isHit;
            }
            set
            {
                this._isHit = value;
            }
        }

        public Grid()
        {

        }

        public Grid(string _position, bool _isOccupied, bool _isHit)
        {
            Position = _position;
            IsOccupied = _isOccupied;
            IsHit = _isHit;
        }

        // Methods here
        
    }
}
