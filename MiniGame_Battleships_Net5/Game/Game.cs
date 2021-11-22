using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships_Net5
{
    public class Game
    {
        static GUI gui = new GUI();

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


        }

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
    }
}
