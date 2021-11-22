using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGame_Battleships_Net5;

namespace MiniGame_Battleships_Net5
{
    public class Board
    {
        public Grid EnemyGrid { get; set; }
        public Grid PlayerGrid { get; set; }
        public Grid RadarGrid { get; set; }
        public Competitor Enemy { get; set; }
        public Competitor Player { get; set; }

        public Board(Grid enemyGrid, Grid playerGrid, Grid radarGrid, Enemy enemy, Player player)
        {
            EnemyGrid = enemyGrid;
            PlayerGrid = playerGrid;
            RadarGrid = radarGrid;
            Enemy = enemy;
            Player = player;
        }
    }
}
