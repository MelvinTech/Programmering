using System;

namespace Retro_RPG
{
    public class Player
    {
        // obs! test data

        public static int Player_HP = 30;
        private static int player_AD = 20;
        private static int player_Armor = 10;
        private static string player_Name;
        private static int player_Level = 1;
        private static int player_Exp = 0;

        public static string Player_name { get { return player_Name; } }

        public static int Player_level { get { return player_Level; } }
        
        public static int Player_Exp { set { player_Exp += value; } }
        
        public static int Player_AD
        {
            get { return player_AD; }
            set
            {
                player_AD += value;

                if (player_AD < 0)
                {
                    player_AD = 0;
                }
            }
        }

        public static int Player_Armor
        {
            get { return player_Armor; }
            set
            {
                player_Armor += value;
                if (player_Armor < 0)
                {
                    player_Armor = 0;
                }
            }
        }

        public Player() // OBS! ändra!
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 3 / 2);
            Console.WriteLine("Welcome adventurer, what is thy name?");
            player_Name = Console.ReadLine();
        }
        public static void Level() // kollar ifall spelaren har tillräkligt mycket exp för att gå upp en level
        {
            if (player_Exp >= 100)
            {
                Level_up();
            }
        }
        private static void Level_up() // Höjer spelarens level med 1
        {
            player_Level++;
            player_Exp -= 100;
            Player_HP += 20;
            player_AD += 5;
            player_Armor += 10;
        }
    }

}
