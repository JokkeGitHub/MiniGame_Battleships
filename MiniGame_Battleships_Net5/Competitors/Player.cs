using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    class Player
    {
        public static GridManager gridManager = new GridManager();
        public static Grid[,] territoryGrid = Board.CreateTerritory(gridManager);
        public static Grid[,] radarGrid = Board.CreateRadar(gridManager);

        public static ShipManager shipManager = new ShipManager();

        public static List<Ship> playerShips = new List<Ship>();
        public static List<Ship> playerPlacedShips = new List<Ship>();

        #region Player Ship Placement
        public static void PlayerSetup()
        {
            playerShips.Add(Board.CreateHangarShip(shipManager));
            playerShips.Add(Board.CreateBattleship(shipManager));
            playerShips.Add(Board.CreateDestroyer(shipManager));
            playerShips.Add(Board.CreateSubmarine(shipManager));
            playerShips.Add(Board.CreatePatrolBoat(shipManager));

            PlayerShipPlacement();

            void PlayerShipPlacement()
            {
                do
                {
                    GUI.DisplayShipTypesMessage();
                    GUI.DisplayPlacementGrid();

                    VerticalOrHorizontal();

                    Console.Clear();
                } while (playerShips.Count != 0);
            }

            void VerticalOrHorizontal()
            {
                GUI.VerticalOrHorizontalMessage();
                string tempAngle = Console.ReadLine().ToUpper();

                if (tempAngle == "V")
                {
                    playerShips[0].Vertical = true;
                }
                else if (tempAngle == "H")
                {
                    playerShips[0].Vertical = false;
                }
                else
                {
                    GUI.ErrorMessage();
                    VerticalOrHorizontal();
                }
                PlaceShip();
            }

            void PlaceShip()
            {
                GUI.PlaceShipMessage();
                string tempPositionInput = Console.ReadLine().ToUpper();

                string positionTemp;

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (tempPositionInput == territoryGrid[i, j].Position)
                        {
                            positionTemp = territoryGrid[i, j].Position;

                            territoryGrid[i, j].Position = playerShips[0].Abbreviation;
                            territoryGrid[i, j].IsOccupied = true;

                            if (playerShips[0].Vertical == true)
                            {
                                if (playerShips[0].Size + i > 10)
                                {
                                    territoryGrid[i, j].Position = positionTemp;
                                    territoryGrid[i, j].IsOccupied = false;

                                    GUI.WrongPlacement();
                                    PlaceShip();

                                    i = 11;
                                    j = 11;
                                }
                                else
                                {
                                    int tempCounter = 0;

                                    for (int k = 1; k < playerShips[0].Size; k++)
                                    {
                                        if (territoryGrid[i + k, j].IsOccupied == true)
                                        {
                                            tempCounter++;
                                        }
                                    }

                                    if (tempCounter == 0)
                                    {
                                        for (int k = 1; k < playerShips[0].Size; k++)
                                        {
                                            territoryGrid[i + k, j].Position = playerShips[0].Abbreviation;
                                            territoryGrid[i + k, j].IsOccupied = true;
                                        }
                                        playerPlacedShips.Add(playerShips[0]);
                                        playerShips.RemoveAt(0);
                                    }
                                    else
                                    {
                                        territoryGrid[i, j].Position = positionTemp;
                                        territoryGrid[i, j].IsOccupied = false;

                                        GUI.WrongPlacement();
                                        PlaceShip();
                                    }
                                }
                            }
                            else
                            {
                                if (playerShips[0].Size + j > 10)
                                {
                                    territoryGrid[i, j].Position = positionTemp;
                                    territoryGrid[i, j].IsOccupied = false;

                                    GUI.WrongPlacement();
                                    PlaceShip();

                                    i = 11;
                                    j = 11;
                                }
                                else
                                {
                                    int tempCounter = 0;

                                    for (int k = 1; k < playerShips[0].Size; k++)
                                    {
                                        if (territoryGrid[i, j + k].IsOccupied == true)
                                        {
                                            tempCounter++;
                                        }
                                    }

                                    if (tempCounter == 0)
                                    {
                                        for (int k = 1; k < playerShips[0].Size; k++)
                                        {
                                            territoryGrid[i, j + k].Position = playerShips[0].Abbreviation;
                                            territoryGrid[i, j + k].IsOccupied = true;
                                        }
                                        playerPlacedShips.Add(playerShips[0]);
                                        playerShips.RemoveAt(0);
                                    }
                                    else
                                    {
                                        territoryGrid[i, j].Position = positionTemp;
                                        territoryGrid[i, j].IsOccupied = false;

                                        GUI.WrongPlacement();
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

        #region Player Turn
        public static void PlayerTarget()
        {
            GUI.SelectTarget();
            string selectedTarget = Console.ReadLine().ToUpper();

            bool validTarget = false;

            foreach (Grid grid in Player.radarGrid)
            {
                if (selectedTarget == grid.Position)
                {
                    validTarget = true;
                }
            }

            if (validTarget == false)
            {
                GUI.InvalidTarget();
                PlayerTarget();
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (selectedTarget == Player.radarGrid[i, j].Position)
                    {
                        if (Enemy.enemyGrid[i, j].IsHit == false)
                        {
                            Enemy.enemyGrid[i, j].IsHit = true;

                            if (Enemy.enemyGrid[i, j].IsOccupied == true)
                            {
                                for (int k = 0; k < Enemy.enemyPlacedShips.Count; k++)
                                {
                                    if (Enemy.enemyPlacedShips[k].Abbreviation == Enemy.enemyGrid[i, j].Position)
                                    {
                                        Enemy.enemyPlacedShips[k].HP--;
                                        if (Enemy.enemyPlacedShips[k].HP == 0)
                                        {
                                            i = 11;
                                            j = 11;

                                            int tempDostroy = DestroyShip(Enemy.enemyPlacedShips.IndexOf(Enemy.enemyPlacedShips[k]));

                                            k = 11;
                                        }
                                        else
                                        {
                                            i = 11;
                                            j = 11;

                                            GUI.YouHitAShip();

                                            k = 11;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i = 11;
                                j = 11;

                                GUI.MissedShot();
                            }
                        }
                        else
                        {
                            GUI.InvalidTarget();

                            i = 11;
                            j = 11;

                            PlayerTarget();
                        }
                    }
                }
            }
        }

        public static int DestroyShip(int shipIndex)
        {
            string destroyedShip = YouHaveDestroyedShipType(Enemy.enemyPlacedShips[shipIndex].Abbreviation);

            Enemy.enemyPlacedShips.RemoveAt(shipIndex);

            return 0;
        }

        public static string YouHaveDestroyedShipType(string shipType)
        {
            switch (shipType)
            {
                case "HS":
                    GUI.DestroyedHangarShip();
                    break;

                case "BS":
                    GUI.DestroyedBattleship();
                    break;

                case "DS":
                    GUI.DestroyedDestroyer();
                    break;

                case "SM":
                    GUI.DestroyedSubmarine();
                    break;

                case "PB":
                    GUI.DestroyedPatrolBoat();
                    break;

                default:
                    break;
            }
            return "";
        }
        #endregion
    }
}
