using System;

namespace MiniGame_Battleships_Net5
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
