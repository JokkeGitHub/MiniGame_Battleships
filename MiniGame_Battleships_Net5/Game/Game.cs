using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Game
    {
        public GUI gui = new GUI();
        public BoardManager boardManager = new BoardManager();
        public Board board;

        #region START UP
        public void Menu()
        {
            do
            {
                gui.StartOrNot();
                bool start = Answer();

                if (start == true)
                {
                    NewGame();
                }

            } while (true);
        }

        bool Answer()
        {
            string answer = Console.ReadLine();
            bool start = false;

            if (answer.ToLower().Contains("yes"))
            {
                start = true;
            }
            else if (answer.ToLower().Contains("no"))
            {
                ExitGame();
            }
            else
            {
                gui.WrongInput();
            }

            return start;
        }

        void ExitGame()
        {
            gui.GoodBye();
            Environment.Exit(0);
        }
        #endregion

        #region GAME SETUP
        void NewGame()
        {
            board = boardManager.CreateBoard();
            ShipPlacement();

            //Determine who starts

            // Loop
            // Display GUI
            // Enemy + Player Turns
            // Check victory condition

            // If victory condition
            // Win/Lose Message
        }

        void ShipPlacement()
        {
            EnemySetup();
            PlayerSetup();
        }

        #region ENEMY PLACEMENT
        void EnemySetup()
        {
            EnemyVerticalOrHorizontal();
            EnemyPlacement();
        }

        void EnemyVerticalOrHorizontal()
        {
            for (int i = 0; i < board.Enemy.Ships.Count; i++)
            {
                board.Enemy.Ships[i].Vertical = board.Enemy.VerticalOrHorizontalPlacement(board.Enemy.Ships[i].Vertical);
            }
        }

        void EnemyPlacement()
        {
            for (int i = 0; i < board.Enemy.Ships.Count; i++)
            {
                board.EnemyGrid = board.Enemy.PositionPlacement(board.EnemyGrid, board.Enemy.Ships[i]);
                board.Enemy.PlacedShips.Add(board.Enemy.Ships[i]);
            }

            board.Enemy.Ships.Clear();
        }
        #endregion

        #region PLAYER PLACEMENT
        void PlayerSetup()
        {
            Console.WriteLine("Test, visible Enemy Grid");
            gui.DisplayPlayerGrid(board.EnemyGrid);

            Console.WriteLine("Reached player setup");
            Console.ReadLine();
            gui.DisplayPlayerGrid(board.PlayerGrid);
            Console.ReadLine();
        }
        #endregion
        #endregion

        /*
        void Run()
        {
            Player.PlayerSetup();
            Enemy.EnemySetup();


            do
            {
                GUI.GameGUI();
                Player.PlayerTarget();
                GUI.GameGUI();
                Enemy.EnemyTurn();

            } while (true);
            // Lave en start game metode
            // Lav en random switch, der bestemmer om spiller eller computer starter
        }
        */
    }
}
