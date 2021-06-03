using System;

namespace Retro_RPG
{
    /// <summary>
    /// Klassen Player används till att skapa nya spelare
    /// </summary>
    public class Player
    {
        // obs! test data, kan ändras för balancing

        private static int player_HP = 20;
        private static int player_AD = 20;
        private static int player_Armor = 10;
        private static string player_Name;
        private static int player_Level = 1;
        private static int player_Exp = 0;

        public static int Player_HP 
        { 
            get { return player_HP; }
            set { player_HP += value; }
        }

        public static string Player_name { get { return player_Name; } set { player_Name = value; } }

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

        public Player(string name) 
        {
            player_Name = name;
        }
        public static void Level() // kollar ifall spelaren har tillräkligt mycket exp för att gå upp en level
        {
            if (player_Exp >= 100)
            {
                Level_up();
            }
        }
        private static void Level_up() // Höjer spelarens level med 1 och kollar ifall spelaren kan gå ipp en level till.
        {
            player_Level++;
            player_Exp -= 100;
            Player_HP += 20;
            player_AD += 5;
            player_Armor += 10;

            if (player_Exp >= 100)
            {
                Level_up();
            }

            if (player_Level >= 3)
            {
                Item.Level_cap = 0;
            }
        }
    }

}
