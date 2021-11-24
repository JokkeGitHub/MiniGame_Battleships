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
            // Positions
            Console.WriteLine(board.EnemyGrid.Cell[0, 0].Position);
            Console.ReadLine();
        }

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
            }
            int positionXnumber = 0;
            int positionYletter = 0;
            board.EnemyGrid.Cell[positionXnumber, positionYletter].Position = board.Enemy.Ships[0].Abbreviation;
        }




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
