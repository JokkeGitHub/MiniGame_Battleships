using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame_Battleships
{
    class Program
    {
        static void Main(string[] args)
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
