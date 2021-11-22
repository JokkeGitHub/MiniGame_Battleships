using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Ship
    {
        public string ShipType { get; set; }
        public string Abbreviation { get; set; }
        public int Size { get; set; }
        public int HP { get; set; }
        public bool Vertical { get; set; }

        public Ship(string shipType, string abbreviation,int size, int hp)
        {
            ShipType = shipType;
            Abbreviation = abbreviation;
            Size = size;
            HP = hp;
        }
    }
}
