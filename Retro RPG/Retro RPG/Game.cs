using System;
using System.IO;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;
using System.Linq;
using System.Globalization;

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
            new Player(Console.ReadLine());
            Game_Over();

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
            Save_score(score);

            Console.Clear();
            Console.SetCursorPosition(standard_pos_x, standard_pos_y);
            Console.WriteLine("Game Over: Final Score: " + score.ToString());
            Write_highscore();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }


        private static void Save_score(int points)
        {
            string fileName = @"Textfiler/Highscore.txt";
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(Player.Player_name, points);
            }
        }

        private static void Write_highscore()
        {
            var highScoreEntries = File.ReadLines("Textfiler/Highscore.txt")
                .Select(line => {
                    string[] parts = line.Split(',');
                    return new { Name = parts[0], Score = int.Parse(parts[1]) };
                })
                .OrderByDescending(highScore => highScore.Score);

            string text = File.ReadLines("Textfiler/Highscore.txt").ToString();
            Console.Write(text);
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
