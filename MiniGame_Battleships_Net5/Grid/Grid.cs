using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Grid
    {
        public Cell[,] Cell { get; set; }

        public Grid(Cell[,] cell)
        {
            Cell = cell;
        }
    }
}
