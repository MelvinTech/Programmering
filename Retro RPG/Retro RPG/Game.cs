using System;
using System.Diagnostics;
using System.Threading;

namespace Final_Project
{
    public class Game
    {
        public static int Score = 0;

        public static void Main()
        {
            new Player();

            new Game_Room();
            
            // OBS! lägg till ordentlig startfunktion
        }
        public static void Update()
        {
            if (Player.Player_HP <= 0)
            {
                Game_Over();
            }
            else
            {
                Player.Level();
                Interface.Update_Interface();
            }
        }
        public static void Game_Over()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over: Final Score: " + Score.ToString());
        }
    }
}
