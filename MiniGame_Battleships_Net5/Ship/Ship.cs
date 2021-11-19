using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class Ship
    {
        private string _shipType;
        private int _size;
        private int _hp;
        private bool _vertical;

        public string ShipType
        {
            get
            {
                return this._shipType;
            }
            set
            {
                this._shipType = value;
            }
        }

        public int Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
            }
        }

        public int HP
        {
            get
            {
                return this._hp;
            }
            set
            {
                this._hp = value;
            }
        }

        public bool Vertical
        {
            get
            {
                return this._vertical;
            }
            set
            {
                this._vertical = value;
            }
        }

        public Ship()
        {

        }

        public Ship(string _shipType, int _size, int _hp)
        {
            ShipType = _shipType;
            Size = _size;
            HP = _hp;
        }

        // Methods here

    }
}
