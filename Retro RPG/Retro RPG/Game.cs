using System;
using System.IO;
using System.Threading;

namespace Retro_RPG
{
    /// <summary>
    /// Klassen Game används för att starta spelet och den innehåller alla bas metoder som uppdatering samt game over och start. 
    /// </summary>
    public class Game
    {
        public static int score = 0;
        private static readonly int error_pos_x = 0;
        private static readonly int error_pos_y = Console.WindowHeight - 4;
        private static readonly int standard_pos_x = 0;
        private static readonly int standard_pos_y = Console.WindowHeight / 2;
        private static readonly int text_pos_x = 0;
        private static readonly int text_pos_y = 1;
        private static string startNR;

        private static readonly string error_command = "Unrecognised command, please try again."; //Används för att enkelt kunna ändra va som sägs vid felinmatnig.

        public static void Main()
        {
            Console.SetWindowSize(120, 35); // Används för att sätta rätt storlek på konsollfönstret.

            Console.WriteLine(File.ReadAllText("Textfiler/Tutorialsheet.txt"));
            Console.ReadKey();
            Game.Update();
            Start();
        }

        public static void Start() //Körs då spelet startar
        {

            Random nr = new Random();
            startNR = nr.Next(1, 4).ToString();

            score = 0;
            Cursor_text_pos();
            Console.WriteLine(File.ReadAllText(@"Textfiler/Start/Start" + startNR + ".txt"));

            string name = Console.ReadLine();
            Player.Player_name = name;
            Update();

            if (name.ToLower() == "admin") //används så att man kan komma till en annan meny
            {
                new Admin();
            }

            new Game_Room();
        }

        public static void Update() //Kallas efter de flesta kommandon och kollar ifall spelaren har förlorat eller gått upp i level.
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
            
            Cursor_text_pos();
            Console.WriteLine("Game Over:\nFinal Score: " + score.ToString());
            Console.WriteLine("Previous Scores:\n");

            Write_HS();
            Highscore();

            Cursor_standard_pos();
            Console.WriteLine("Would you like to try again?");
            Console.WriteLine("1. Yes\n2. No");

            string ans = Console.ReadLine();

            if (ans == "1")
            {
                Console.Clear();
                Start();
            }
            else 
            {
                Environment.Exit(1);
            }
        }

        private static void Highscore() //Skriver ut poäng i en fil på datorn.
        {
            string text = File.ReadAllText("Textfiler/Highscore.txt");

            using (StreamWriter outputFile = new StreamWriter("Textfiler/Highscore.txt"))
            {
                outputFile.WriteLine(text + Player.Player_name + " " + score);
            }
        }

        private static void Write_HS() //Skriver ut poängen på skärmen.
        {
            if (File.Exists("Textfiler/Highscore.txt") == false)
            {
                File.Create("Textfiler/Highscore.txt");
                Thread.Sleep(200); //används eftersom att datorn behöver en kort paus för att skapa textfilen ifall den inte finns.
            }

            Console.Write(File.ReadAllText("Textfiler/Highscore.txt"));
        }

        public static void Error_message() //Används när spelaren slår in ett felaktigt kommando.
        {
            Console.SetCursorPosition(error_pos_x, error_pos_y);
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
