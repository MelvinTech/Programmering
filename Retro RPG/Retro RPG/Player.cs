using System;

namespace Retro_RPG
{
    public class Player
    {
        // obs! test data

        public static double Player_HP = 30;
        private static double Player_AD = 20;
        private static double Player_Armor = 10;
        private static string Player_Name;
        private static double Player_Level = 1;
        private static double Player_Exp = 0;

        public static string Pname_get() { return Player_Name; }

        public static void PAD_set(double AD_change) { Player_AD += AD_change; }
        public static double PAD_get() { return Player_AD; }

        public static void Parmor_set(double armor_change) 
        {
            double DParmor = Player_Armor;

            if ((DParmor += armor_change) < 0)
            {
                Player_Armor = 0;
            }
            else
            {
                Player_Armor += armor_change;
            }
        }
        public static double Parmor_get() { return Player_Armor; }

        public static double Plevel_get() { return Player_Level; }

        public static void Pexp_set(double EXP_change) { Player_Exp += EXP_change;}

        public Player() // OBS! ändra!
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 3 / 2);
            Console.WriteLine("Welcome adventurer, what is thy name?");
            Player_Name = Console.ReadLine();
        }
        public static void Level() // kollar ifall spelaren har tillräkligt mycket exp för att gå upp en level
        {
            if (Player_Exp >= 100)
            {
                Level_up();
            }
        }
        private static void Level_up() // Höjer spelarens level med 1
        {
            Player_Level++;
            Player_Exp -= 100;
            Player_HP += 20;
            Player_AD += 5;
            Player_Armor += 10;
        }
    }

}
