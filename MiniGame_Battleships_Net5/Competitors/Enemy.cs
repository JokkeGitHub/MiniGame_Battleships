using MiniGame_Battleships_Net5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Enemy : Competitor
    {
        public Random random = new Random();
        public Game game;

        public Enemy(List<Ship> ships, List<Ship> placedShips)
        {
            Ships = ships;
            PlacedShips = placedShips;
        }

        #region PLACEMENT
        public override bool VerticalOrHorizontalPlacement(bool vertical)
        {
            int vertialOrHorizontal = random.Next(0, 2);

            switch (vertialOrHorizontal)
            {
                case 0:
                    vertical = true;
                    break;

                case 1:
                    vertical = false;
                    break;

                default:
                    VerticalOrHorizontalPlacement(vertical);
                    break;
            }

            return vertical;
        }

        public override Grid PositionPlacement(Grid grid, Ship ship)
        {
            bool allPositionsAvailable = false;
            int positionYletter;
            int positionXnumber;

            do
            {
                positionYletter = random.Next(0, 10);
                positionXnumber = random.Next(0, 10);

                if (grid.Cell[positionYletter, positionXnumber].IsOccupied == false)
                {
                    allPositionsAvailable = CheckPositionAvailability(grid, positionYletter, positionXnumber, ship.Vertical, ship.Size, allPositionsAvailable);
                }

            } while (allPositionsAvailable == false);

            grid = PlaceShip(grid, ship, positionYletter, positionXnumber);

            return grid;
        }

        public bool CheckPositionAvailability(Grid grid, int positionY, int positionX, bool shipVertical, int shipSize, bool allPositionsAvailable)
        {
            if (shipVertical == true && positionY + shipSize < 10)
            {
                allPositionsAvailable = CheckVerticalPosition(grid, positionY, positionX, shipSize, allPositionsAvailable);
            }
            else if (shipVertical == false && positionX + shipSize < 10)
            {
                allPositionsAvailable = CheckHorizontalPosition(grid, positionY, positionX, shipSize, allPositionsAvailable);
            }
            else
            {
                allPositionsAvailable = false;
            }

            return allPositionsAvailable;
        }

        public bool CheckVerticalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable)
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (grid.Cell[positionY + i, positionX].IsOccupied == false)
                {
                    allPositionsAvailable = true;
                }
                else
                {
                    allPositionsAvailable = false;
                    i = 6;
                }
            }

            return allPositionsAvailable;
        }

        public bool CheckHorizontalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable)
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (grid.Cell[positionY, positionX + i].IsOccupied == false)
                {
                    allPositionsAvailable = true;
                }
                else
                {
                    allPositionsAvailable = false;
                    i = 6;
                }
            }

            return allPositionsAvailable;
        }

        public Grid PlaceShip(Grid grid, Ship ship, int positionY, int positionX)
        {
            if (ship.Vertical == true)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    grid.Cell[positionY + i, positionX].ShipAtLocation = ship;
                    grid.Cell[positionY + i, positionX].IsOccupied = true; 
                    //Console.WriteLine($"position {grid.Cell[positionY + i, positionX].Position} occupied by {grid.Cell[positionY + i, positionX].ShipAtLocation.Abbreviation}");
                }
            }
            else
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    grid.Cell[positionY, positionX + i].ShipAtLocation = ship;
                    grid.Cell[positionY, positionX + i].IsOccupied = true;
                    //Console.WriteLine($"position {grid.Cell[positionY, positionX + i].Position} occupied by {grid.Cell[positionY, positionX + i].ShipAtLocation.Abbreviation}");
                }
            }

            return grid;
        }
        #endregion






        /// <summary>
        /// ///////////////////////////// OLD CODE BELOW
        /// </summary>
        /// <param name="ships"></param>
        /// <returns></returns>

        /*
         
        static Random random = new Random();

        #region Enemy Ship Placement

            void PlaceShip()
            {
                string positionTemp;

                int tempGridVertical = random.Next(0, 10);
                int tempGridHorizontal = random.Next(0, 10);
                string tempPositionInput = Player.radarGrid[tempGridVertical, tempGridHorizontal].Position;


                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (tempPositionInput == enemyGrid[i, j].Position)
                        {
                            positionTemp = enemyGrid[i, j].Position;

                            enemyGrid[i, j].Position = enemyShips[0].Abbreviation;
                            enemyGrid[i, j].IsOccupied = true;

                            if (enemyShips[0].Vertical == true)
                            {
                                if (enemyShips[0].Size + i > 10)
                                {
                                    enemyGrid[i, j].Position = positionTemp;
                                    enemyGrid[i, j].IsOccupied = false;

                                    PlaceShip();

                                    i = 11;
                                    j = 11;
                                }
                                else
                                {
                                    int tempCounter = 0;

                                    for (int k = 1; k < enemyShips[0].Size; k++)
                                    {
                                        if (enemyGrid[i + k, j].IsOccupied == true)
                                        {
                                            tempCounter++;
                                        }
                                    }

                                    if (tempCounter == 0)
                                    {
                                        for (int k = 1; k < enemyShips[0].Size; k++)
                                        {
                                            enemyGrid[i + k, j].Position = enemyShips[0].Abbreviation;
                                            enemyGrid[i + k, j].IsOccupied = true;
                                        }
                                        enemyPlacedShips.Add(enemyShips[0]);
                                        enemyShips.RemoveAt(0);
                                    }
                                    else
                                    {
                                        enemyGrid[i, j].Position = positionTemp;
                                        enemyGrid[i, j].IsOccupied = false;

                                        PlaceShip();
                                    }
                                }
                            }
                            else
                            {
                                if (enemyShips[0].Size + j > 10)
                                {
                                    enemyGrid[i, j].Position = positionTemp;
                                    enemyGrid[i, j].IsOccupied = false;

                                    PlaceShip();

                                    i = 11;
                                    j = 11;
                                }
                                else
                                {
                                    int tempCounter = 0;

                                    for (int k = 1; k < enemyShips[0].Size; k++)
                                    {
                                        if (enemyGrid[i, j + k].IsOccupied == true)
                                        {
                                            tempCounter++;
                                        }
                                    }

                                    if (tempCounter == 0)
                                    {
                                        for (int k = 1; k < enemyShips[0].Size; k++)
                                        {
                                            enemyGrid[i, j + k].Position = enemyShips[0].Abbreviation;
                                            enemyGrid[i, j + k].IsOccupied = true;
                                        }
                                        enemyPlacedShips.Add(enemyShips[0]);
                                        enemyShips.RemoveAt(0);
                                    }
                                    else
                                    {
                                        enemyGrid[i, j].Position = positionTemp;
                                        enemyGrid[i, j].IsOccupied = false;

                                        PlaceShip();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Enemy Turn

        public static void EnemyTurn()
        {
            int verticalRandom = random.Next(0, 10);
            int horizontalRandom = random.Next(0, 10);

            EnemyTarget(verticalRandom, horizontalRandom);
        }

        public static void EnemyTarget(int tempTargetVertical, int tempTargetHorizontal)
        {
            string selectedTarget = Player.radarGrid[tempTargetVertical, tempTargetHorizontal].Position;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (selectedTarget == Player.radarGrid[i, j].Position)
                    {
                        if (Player.territoryGrid[i, j].IsHit == false)
                        {
                            Player.territoryGrid[i, j].IsHit = true;

                            if (Player.territoryGrid[i, j].IsOccupied == true)
                            {

                                for (int k = 0; k < Player.playerPlacedShips.Count; k++)
                                {
                                    if (Player.playerPlacedShips[k].Abbreviation == Player.territoryGrid[i, j].Position)
                                    {
                                        Player.playerPlacedShips[k].HP--;
                                        if (Player.playerPlacedShips[k].HP == 0)
                                        {
                                            i = 11;
                                            j = 11;

                                            int tempDestroy = EnemyDestroyShip(Player.playerPlacedShips.IndexOf(Player.playerPlacedShips[k]));

                                            k = 11;
                                        }
                                        else
                                        {
                                            i = 11;
                                            j = 11;

                                            GUI.EnemyHitAShip();

                                            k = 11;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i = 11;
                                j = 11;

                                GUI.EnemyMissedShot();
                            }
                        }
                        else
                        {
                            i = 11;
                            j = 11;

                            EnemyTurn();
                        }
                    }
                }
            }
        }

        public static int EnemyDestroyShip(int shipIndex)
        {
            GUI.EnemyDestroyedAShip(Player.playerPlacedShips[shipIndex].ShipType);

            Player.playerPlacedShips.RemoveAt(shipIndex);

            return 0;
        }
        #endregion
        */
    }
}
