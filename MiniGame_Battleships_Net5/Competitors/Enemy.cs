using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class Enemy
    {
        public static GridManager gridManager = new GridManager();
        public static Grid[,] enemyGrid = Board.CreateEnemyTerritory(gridManager);

        public static ShipManager shipManager = new ShipManager();
        public static Ship enemyShip1 = Board.CreateHangarShip(shipManager);
        public static Ship enemyShip2 = Board.CreateBattleship(shipManager);
        public static Ship enemyShip3 = Board.CreateDestroyer(shipManager);
        public static Ship enemyShip4 = Board.CreateSubmarine(shipManager);
        public static Ship enemyShip5 = Board.CreatePatrolBoat(shipManager);

        public static List<Ship> enemyShips = new List<Ship>();
        public static List<Ship> enemyPlacedShips = new List<Ship>();

        static Random random = new Random();

        #region Enemy Ship Placement
        public static void EnemySetup()
        {
            Random random = new Random();

            enemyShips.Add(enemyShip1);
            enemyShips.Add(enemyShip2);
            enemyShips.Add(enemyShip3);
            enemyShips.Add(enemyShip4);
            enemyShips.Add(enemyShip5);

            PlayerShipPlacement();

            void PlayerShipPlacement()
            {
                do
                {
                    VerticalOrHorizontal();

                } while (enemyShips.Count != 0);
            }

            void VerticalOrHorizontal()
            {
                int tempAngleRandom = random.Next(0, 2);

                if (tempAngleRandom == 0)
                {
                    enemyShips[0].Vertical = true;
                }
                else if (tempAngleRandom == 1)
                {
                    enemyShips[0].Vertical = false;
                }
                else
                {
                    VerticalOrHorizontal();
                }
                PlaceShip();
            }

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

                            enemyGrid[i, j].Position = enemyShips[0].ShipType;
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
                                            enemyGrid[i + k, j].Position = enemyShips[0].ShipType;
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
                                            enemyGrid[i, j + k].Position = enemyShips[0].ShipType;
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
                                    if (Player.playerPlacedShips[k].ShipType == Player.territoryGrid[i, j].Position)
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
            string destroyedShip = EnemyHaveDestroyedShipType(Player.playerPlacedShips[shipIndex].ShipType);

            Player.playerPlacedShips.RemoveAt(shipIndex);

            return 0;
        }

        public static string EnemyHaveDestroyedShipType(string shipType)
        {
            switch (shipType)
            {
                case "HS":
                    GUI.EnemyDestroyedHangarShip();
                    break;

                case "BS":
                    GUI.EnemyDestroyedBattleship();
                    break;

                case "DS":
                    GUI.EnemyDestroyedDestroyer();
                    break;

                case "SM":
                    GUI.EnemyDestroyedSubmarine();
                    break;

                case "PB":
                    GUI.EnemyDestroyedPatrolBoat();
                    break;

                default:
                    break;
            }
            return "";
        }
        #endregion
    }
}
