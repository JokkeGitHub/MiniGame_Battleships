using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Player : Competitor
    {
        public GUI gui = new GUI();
        public Game game = new Game();


        public Player(List<Ship> ships, List<Ship> placedShips)
        {
            Ships = ships;
            PlacedShips = placedShips;
        }

        public override bool VerticalOrHorizontalPlacement(bool vertical)
        {
            string verticalOrHorizontal = "";
            do
            {
                verticalOrHorizontal = Console.ReadLine();

                if (verticalOrHorizontal.ToLower() == "v")
                {
                    vertical = true;
                }
                else if (verticalOrHorizontal.ToLower() == "h")
                {
                    vertical = false;
                }
                else
                {
                    gui.WrongInput();
                }

            } while (verticalOrHorizontal == "");

            return vertical;
        }

        public override Grid PositionPlacement(Grid grid, Ship ship)
        {
            int positionYletter = 0;
            int positionXnumber = 0;
            bool positionFound = false;
            bool allPositionsAvailable = false;

            game.PlayerPlacementGrid();
            gui.ChooseCellMessage(ship);
            string chosenPosition = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (grid.Cell[i, j].Position == chosenPosition.ToUpper())
                    {
                        positionYletter = i;
                        positionXnumber = j;
                        positionFound = true;

                        i = 11;
                        j = 11;
                    }
                }
            }

            if (positionFound == true)
            {
                //allPositionsAvailable = CheckPositionAvailability(grid, positionYletter, positionXnumber, ship.Vertical, ship.Size, allPositionsAvailable);
                Console.WriteLine($"Made it this far. {chosenPosition}");
                Console.ReadLine();
            }

            if (allPositionsAvailable == true)
            {
                grid = PlaceShip(grid, ship, positionYletter, positionXnumber);
            }
            else
            {
                gui.WrongInput();
                PositionPlacement(grid, ship);
            }

            return grid;
        }

        public override bool CheckPositionAvailability(Grid grid, int positionY, int positionX, bool shipVertical, int shipSize, bool allPositionsAvailable)
        {

            return allPositionsAvailable;
        }

        public override bool CheckVerticalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable)
        {

            return allPositionsAvailable;
        }

        public override bool CheckHorizontalPosition(Grid grid, int positionY, int positionX, int shipSize, bool allPositionsAvailable)
        {

            return allPositionsAvailable;
        }

        public override Grid PlaceShip(Grid grid, Ship ship, int positionY, int positionX)
        {

            return grid;
        }




        /// <summary>
        /// ///////////////////////////////////////// OLD CODE BELOW
        /// </summary>
        /// <param name="ships"></param>
        /// <returns></returns>


        /*
        #region Player Ship Placement
        public static void PlayerSetup()
        {

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

            foreach (Cell grid in Player.radarGrid)
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
            GUI.YouDestroyedAShip(Enemy.enemyPlacedShips[shipIndex].ShipType);

            Enemy.enemyPlacedShips.RemoveAt(shipIndex);

            return 0;
        }
        #endregion
        */
    }
}
