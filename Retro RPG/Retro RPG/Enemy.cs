using System;

namespace Final_Project
{
    public class Enemy
    {
        public static string Name;
        public static int HP = 0;
        public static int Armor = 0;
        public static int AD = 0;
        public static int Level_stats = 0;

        public Enemy()
        {
            Bonus_Stats();
            Random random1 = new Random();
            int num = random1.Next(0, 1001);

            if (num > 0 && num < 333)
            {
                Goblin(); // Väljer Goblin som motståndare och ger dess stats
            }
            else if (num > 332 && num < 666)
            {
                Orc(); // Väljer Orc som motståndare och ger dess stats
            }
            else if (num > 666 && num < 999) 
            {
                Witch(); // Väljer Witch som motståndare och ger dess stats
            }
            else
            {
                RaidBoss(); // Väljer RaidBoss som motståndare och ger dess stats
            }
        }
        private void Bonus_Stats() // lägger till mer stats för att motverka spelarens ökande styrkor.
        {
            Level_stats = 10 * Player.Player_Level;
        }

        // följande metoder bestämmer fiendens stats
        // OBS! Test data för alla motståndare ändra senare för balancing 
        public static void Goblin()
        {
            Name = "Goblin";
            HP = 20 + Level_stats;
            Armor = -5 + Level_stats;
            AD = 10 + Level_stats;    
        }
        public static void Orc()
        {
            Name = "Orc";
            HP = 40 + Level_stats;
            Armor = -2 + Level_stats;
            AD = 6 + Level_stats;
        }
        public static void Witch()
        {
            Name = "Witch";
            HP = 15 + Level_stats;
            Armor = 0 + Level_stats;
            AD = 20 + Level_stats;
        }
        public static void RaidBoss()
        {
            Name = "RaidBoss";
            HP = 350 + Level_stats;
            Armor = 70 + Level_stats;
            AD = 120 + Level_stats;
        }
    }
}
