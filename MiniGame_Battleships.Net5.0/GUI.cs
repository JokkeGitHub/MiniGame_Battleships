using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships.Net5._0
{
    class GUI
    {
        #region Ship Placement GUI
        public static void DisplayShipTypesMessage()
        {
            Console.WriteLine("[HS] = Hangar Ship| Size = 5\n[BS] = Battleship | Size = 4\n[DS] = Destroyer  | Size = 3\n[SM] = Submarine  | Size = 3\n[PB] = Patrol Boat| Size = 2\n");
        }

        public static void DisplayPlacementGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Player.territoryGrid[i, j].IsOccupied == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {Player.territoryGrid[i, j].Position} ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write($" {Player.territoryGrid[i, j].Position} ");
                    }
                }
                Console.Write("\n");
            }
        }

        public static void VerticalOrHorizontalMessage()
        {
            Console.WriteLine($"Would you like the {Player.playerShips[0].ShipType} to be [v]vertical or [h]horizontal?");
        }

        public static void PlaceShipMessage()
        {
            Console.WriteLine($"Where would you like to place this [{Player.playerShips[0].ShipType}]?");
            Console.WriteLine("Enter the position where you want the ship placed.");
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Wrong input detected, please try again.");
        }

        public static void WrongPlacement()
        {
            Console.WriteLine("Something went wrong with the placement. Check the size of the ship and try again.");
        }
        #endregion

        #region Game Board GUI
        public static void GameGUI()
        {
            Console.Clear();
            RadarGUI();
            TerritoryGUI();
        }

        public static void RadarGUI()
        {
            Console.WriteLine("***************** RADAR *****************");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Enemy.enemyGrid[i, j].IsHit == true && Enemy.enemyGrid[i, j].IsOccupied == false)
                    {
                        ShotMissed();
                    }
                    else if (Enemy.enemyGrid[i, j].IsHit == true && Enemy.enemyGrid[i, j].IsOccupied == true)
                    {
                        ShotHit();
                    }
                    else
                    {
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(Player.radarGrid[i, j].Position);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("]");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("*****************************************");
        }

        public static void TerritoryGUI()
        {
            Console.WriteLine("*************** TERRITORY ***************");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Player.territoryGrid[i, j].IsHit == true && Player.territoryGrid[i, j].IsOccupied == false)
                    {
                        ShotMissed();
                    }
                    else if (Player.territoryGrid[i, j].IsHit == true && Player.territoryGrid[i, j].IsOccupied == true)
                    {
                        ShotHit();
                    }
                    else if (Player.territoryGrid[i, j].IsOccupied == true && Player.territoryGrid[i, j].IsHit == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write($"{Player.territoryGrid[i, j].Position}");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("]");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("    ");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("*****************************************");
        }

        public static void ShotMissed()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("wWWw");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShotHit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[><]");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region Player turn messages
        public static void SelectTarget()
        {
            Console.WriteLine("Choose a target location on the 'RADAR' to shoot at :");
        }

        public static void InvalidTarget()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The target location is invalid. Try again");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MissedShot()
        {
            Console.WriteLine("You missed your shot and hit nothing but waves");
            Console.ReadLine();
        }

        public static void YouHitAShip()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You hit an enemy ship!");
            Console.ReadLine();
        }

        public static void DestroyedHangarShip()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have destroyed the enemys Hangar Ship!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void DestroyedBattleship()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have destroyed the enemys Battleship!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void DestroyedDestroyer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have destroyed the enemys Destroyer!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void DestroyedSubmarine()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have destroyed the enemys Submarine!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void DestroyedPatrolBoat()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have destroyed the enemys Patrol Boat!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        #endregion

        #region Enemy turn messages
        public static void EnemyMissedShot()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The enemy missed their shot and hit nothing but waves!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyHitAShip()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy hit one of your ships!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyDestroyedHangarShip()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy has destroyed your Hangar Ship!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyDestroyedBattleship()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy has destroyed your Battleship!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyDestroyedDestroyer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy has destroyed your Destroyer!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyDestroyedSubmarine()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy has destroyed your Submarine!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void EnemyDestroyedPatrolBoat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy has destroyed your Patrol Boat!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        #endregion
    }
}
