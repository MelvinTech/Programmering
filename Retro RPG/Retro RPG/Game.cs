using System;

namespace Retro_RPG
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
                Console.SetCursorPosition(0, 10);
            }
        }
        public static void Game_Over()
        {
            Console.Clear();

            /*try
            {
                StreamWriter sw = new StreamWriter(".HighScore.txt");
                sw.WriteLine(Game.Score.ToString());
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            string line;
            try
            {
                StreamReader sr = new StreamReader(".HighScore.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            */
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Game Over: Final Score: " + Score.ToString());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
