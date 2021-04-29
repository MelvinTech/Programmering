using System;
using System.IO;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;

namespace Retro_RPG
{
    public class Game
    {
        public static int Score = 0;
        private static readonly int error_pos_x = 1;
        private static readonly int error_pos_y = Console.WindowHeight - 3;
        private static readonly int standard_pos_x = 0;
        private static readonly int standard_pos_y = Console.WindowHeight / 2;
        private static readonly int text_pos_x = 0;
        private static readonly int text_pos_y = 1;


        private static readonly string error_command = "Unrecognised command, please try again.";

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

            Game_Room.Single_Path();

            new Game_Room();

            // OBS! lägg till ordentlig startfunktion
        }

        public static void Update() //Kallas efter varje kommando.
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
        public static void Game_Over() // Körs när spelaren har 0 eller mindre HP kver. 
        {
            Console.Clear();
            Console.SetCursorPosition(standard_pos_x, standard_pos_y);
            Console.WriteLine("Game Over: Final Score: " + Score.ToString());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public static void Error_message() //Används när spelaren slår in ett felaktigt kommando.
        {
            Console.SetCursorPosition(Game.Error_pos_x, Game.Error_pos_y);
            Console.Write(error_command);
        }
        public static void Cursor_standard_pos() //Används för att sätta pekaren på en standard position vid varje nytt kommando.
        {
            Console.SetCursorPosition(standard_pos_x, standard_pos_y);
        }

        public static void Cursor_text_pos()
        {
            Console.SetCursorPosition(text_pos_x, text_pos_y);
        }
    }
}
