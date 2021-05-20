using System;
using System.IO;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Retro_RPG
{
    public class Game
    {
        public static int score = 0;
        private static readonly int error_pos_x = 0;
        private static readonly int error_pos_y = Console.WindowHeight - 4;
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
            Console.SetWindowSize(120, 35); // Används för att sätta rätt storlek på konsollfönstret.
            Start();
        }

        public static void Start()
        {

            score = 0;
            Cursor_text_pos();
            Console.WriteLine(" Rogue: Devolved");
            Console.WriteLine("\n Welcome to the dungeon! What you will meet within I cannot say. \n Will you meet your maker or will you see your way through the darkness?");
            Console.WriteLine("\n Before you enter you must know that reaching a satisfying ending is \n difficult and time consuming. You will not do on your first try!");
            Console.WriteLine(" Now, what is thy name adventurer! \n ");

            new Player(Console.ReadLine());
            Update();

            new Game_Room();
        }

        public static void Update() //Kallas efter de flesta kommandon.
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
            Highscore();
            Write_HS();
            Console.SetCursorPosition(standard_pos_x, standard_pos_y);
            Console.WriteLine("Game Over: Final Score: " + score.ToString());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }

        static void Highscore()
        {
            string text = File.ReadAllText("Textfiler/Highscore.txt");

            using (StreamWriter outputFile = new StreamWriter("Textfiler/Highscore.txt"))
            {
                outputFile.WriteLine(text + Player.Player_name + " " + score);
            }
        }

        static void Write_HS()
        {
            Console.Write(File.ReadAllText("Textfiler/Highscore.txt"));
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

        public static void Cursor_text_pos() //Används för att sätta pekaren på rätt ställe för text.
        {
            Console.SetCursorPosition(text_pos_x, text_pos_y);
        }
    }
}
