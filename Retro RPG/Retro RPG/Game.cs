using System;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;

namespace Retro_RPG
{
    public class Game
    {
        public static int Score = 0;
        private static int error_pos_x = 1;
        private static int error_pos_y = Console.WindowHeight - 3;
        private static int standard_pos_x = 1;
        private static int standard_pos_y = Console.WindowHeight / 2;

        private static string error_command = "Unrecognised command, please try again.";

        public static int Error_pos_x
        {
            get { return error_pos_x; }
        }
        public static int Error_pos_y
        {
            get { return error_pos_y; }
        }

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
                Console.SetCursorPosition(0, 10);
            }
        }
        public static void Game_Over()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over: Final Score: " + Score.ToString());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public static void Error_message()
        {
            Console.SetCursorPosition(Game.Error_pos_x, Game.Error_pos_y);
            Console.Write(error_command);
        }
        public static void Cursor_standard_pos()
        {
            Console.SetCursorPosition(standard_pos_x, standard_pos_y);
        }
    }
}
