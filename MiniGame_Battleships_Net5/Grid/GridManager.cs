using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class GridManager
    {
        public Grid CreateGrid()
        {
            Cell[,] cells = GetCells();

            Grid grid = new Grid(cells);

            return grid;
        }

        public Cell[,] GetCells()
        {
            CellManager cellManager = new CellManager();

            Cell[,] cells = new Cell[10, 10];
            {
                { cells[0, 0] = cellManager.CreatePosition("A0", false, false); cells[0, 1] = cellManager.CreatePosition("A1", false, false); cells[0, 2] = cellManager.CreatePosition("A2", false, false); cells[0, 3] = cellManager.CreatePosition("A3", false, false); cells[0, 4] = cellManager.CreatePosition("A4", false, false); cells[0, 5] = cellManager.CreatePosition("A5", false, false); cells[0, 6] = cellManager.CreatePosition("A6", false, false); cells[0, 7] = cellManager.CreatePosition("A7", false, false); cells[0, 8] = cellManager.CreatePosition("A8", false, false); cells[0, 9] = cellManager.CreatePosition("A9", false, false); }
                { cells[1, 0] = cellManager.CreatePosition("B0", false, false); cells[1, 1] = cellManager.CreatePosition("B1", false, false); cells[1, 2] = cellManager.CreatePosition("B2", false, false); cells[1, 3] = cellManager.CreatePosition("B3", false, false); cells[1, 4] = cellManager.CreatePosition("B4", false, false); cells[1, 5] = cellManager.CreatePosition("B5", false, false); cells[1, 6] = cellManager.CreatePosition("B6", false, false); cells[1, 7] = cellManager.CreatePosition("B7", false, false); cells[1, 8] = cellManager.CreatePosition("B8", false, false); cells[1, 9] = cellManager.CreatePosition("B9", false, false); }
                { cells[2, 0] = cellManager.CreatePosition("C0", false, false); cells[2, 1] = cellManager.CreatePosition("C1", false, false); cells[2, 2] = cellManager.CreatePosition("C2", false, false); cells[2, 3] = cellManager.CreatePosition("C3", false, false); cells[2, 4] = cellManager.CreatePosition("C4", false, false); cells[2, 5] = cellManager.CreatePosition("C5", false, false); cells[2, 6] = cellManager.CreatePosition("C6", false, false); cells[2, 7] = cellManager.CreatePosition("C7", false, false); cells[2, 8] = cellManager.CreatePosition("C8", false, false); cells[2, 9] = cellManager.CreatePosition("C9", false, false); }
                { cells[3, 0] = cellManager.CreatePosition("D0", false, false); cells[3, 1] = cellManager.CreatePosition("D1", false, false); cells[3, 2] = cellManager.CreatePosition("D2", false, false); cells[3, 3] = cellManager.CreatePosition("D3", false, false); cells[3, 4] = cellManager.CreatePosition("D4", false, false); cells[3, 5] = cellManager.CreatePosition("D5", false, false); cells[3, 6] = cellManager.CreatePosition("D6", false, false); cells[3, 7] = cellManager.CreatePosition("D7", false, false); cells[3, 8] = cellManager.CreatePosition("D8", false, false); cells[3, 9] = cellManager.CreatePosition("D9", false, false); }
                { cells[4, 0] = cellManager.CreatePosition("E0", false, false); cells[4, 1] = cellManager.CreatePosition("E1", false, false); cells[4, 2] = cellManager.CreatePosition("E2", false, false); cells[4, 3] = cellManager.CreatePosition("E3", false, false); cells[4, 4] = cellManager.CreatePosition("E4", false, false); cells[4, 5] = cellManager.CreatePosition("E5", false, false); cells[4, 6] = cellManager.CreatePosition("E6", false, false); cells[4, 7] = cellManager.CreatePosition("E7", false, false); cells[4, 8] = cellManager.CreatePosition("E8", false, false); cells[4, 9] = cellManager.CreatePosition("E9", false, false); }
                { cells[5, 0] = cellManager.CreatePosition("F0", false, false); cells[5, 1] = cellManager.CreatePosition("F1", false, false); cells[5, 2] = cellManager.CreatePosition("F2", false, false); cells[5, 3] = cellManager.CreatePosition("F3", false, false); cells[5, 4] = cellManager.CreatePosition("F4", false, false); cells[5, 5] = cellManager.CreatePosition("F5", false, false); cells[5, 6] = cellManager.CreatePosition("F6", false, false); cells[5, 7] = cellManager.CreatePosition("F7", false, false); cells[5, 8] = cellManager.CreatePosition("F8", false, false); cells[5, 9] = cellManager.CreatePosition("F9", false, false); }
                { cells[6, 0] = cellManager.CreatePosition("G0", false, false); cells[6, 1] = cellManager.CreatePosition("G1", false, false); cells[6, 2] = cellManager.CreatePosition("G2", false, false); cells[6, 3] = cellManager.CreatePosition("G3", false, false); cells[6, 4] = cellManager.CreatePosition("G4", false, false); cells[6, 5] = cellManager.CreatePosition("G5", false, false); cells[6, 6] = cellManager.CreatePosition("G6", false, false); cells[6, 7] = cellManager.CreatePosition("G7", false, false); cells[6, 8] = cellManager.CreatePosition("G8", false, false); cells[6, 9] = cellManager.CreatePosition("G9", false, false); }
                { cells[7, 0] = cellManager.CreatePosition("H0", false, false); cells[7, 1] = cellManager.CreatePosition("H1", false, false); cells[7, 2] = cellManager.CreatePosition("H2", false, false); cells[7, 3] = cellManager.CreatePosition("H3", false, false); cells[7, 4] = cellManager.CreatePosition("H4", false, false); cells[7, 5] = cellManager.CreatePosition("H5", false, false); cells[7, 6] = cellManager.CreatePosition("H6", false, false); cells[7, 7] = cellManager.CreatePosition("H7", false, false); cells[7, 8] = cellManager.CreatePosition("H8", false, false); cells[7, 9] = cellManager.CreatePosition("H9", false, false); }
                { cells[8, 0] = cellManager.CreatePosition("I0", false, false); cells[8, 1] = cellManager.CreatePosition("I1", false, false); cells[8, 2] = cellManager.CreatePosition("I2", false, false); cells[8, 3] = cellManager.CreatePosition("I3", false, false); cells[8, 4] = cellManager.CreatePosition("I4", false, false); cells[8, 5] = cellManager.CreatePosition("I5", false, false); cells[8, 6] = cellManager.CreatePosition("I6", false, false); cells[8, 7] = cellManager.CreatePosition("I7", false, false); cells[8, 8] = cellManager.CreatePosition("I8", false, false); cells[8, 9] = cellManager.CreatePosition("I9", false, false); }
                { cells[9, 0] = cellManager.CreatePosition("J0", false, false); cells[9, 1] = cellManager.CreatePosition("J1", false, false); cells[9, 2] = cellManager.CreatePosition("J2", false, false); cells[9, 3] = cellManager.CreatePosition("J3", false, false); cells[9, 4] = cellManager.CreatePosition("J4", false, false); cells[9, 5] = cellManager.CreatePosition("J5", false, false); cells[9, 6] = cellManager.CreatePosition("J6", false, false); cells[9, 7] = cellManager.CreatePosition("J7", false, false); cells[9, 8] = cellManager.CreatePosition("J8", false, false); cells[9, 9] = cellManager.CreatePosition("J9", false, false); }
            };
            return cells;
        }
    }
}
