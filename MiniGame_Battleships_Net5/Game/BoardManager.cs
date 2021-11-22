using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class BoardManager
    {
        public Board CreateBoard()
        {
            GridManager gridManager = new GridManager();

            Grid enemyGrid = gridManager.CreateGrid();
            Grid playerGrid = gridManager.CreateGrid();
            Grid radarGrid = gridManager.CreateGrid();

            Enemy enemy = new Enemy();
            Player player = new Player();

            Board newBoard = new Board(enemyGrid, playerGrid, radarGrid, enemy, player);

            return newBoard;
        }
    }
}
