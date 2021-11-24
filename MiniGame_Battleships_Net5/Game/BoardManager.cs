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

            List<Ship> shipsListEnemy = new List<Ship>();
            List<Ship> shipsListEnemyPlaced = new List<Ship>();
            List<Ship> shipsListPlayer = new List<Ship>();
            List<Ship> shipsListPlayerPlaced = new List<Ship>();

            Enemy enemy = new Enemy(shipsListEnemy, shipsListEnemyPlaced);
            Player player = new Player(shipsListPlayer, shipsListPlayerPlaced);

            enemy.Ships = enemy.GetShipList();
            player.Ships = player.GetShipList();

            Board newBoard = new Board(enemyGrid, playerGrid, radarGrid, enemy, player);

            return newBoard;
        }
    }
}
