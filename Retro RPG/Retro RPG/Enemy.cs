using System;

namespace Retro_RPG
{
    public class Enemy
    {
        private static string enemy_name;
        private static int enemy_HP = 0;
        private static int enemy_armor = 0;
        private static int enemy_AD = 0;
        private static int Level_stats = 0;

        public static string Enemy_name { get { return enemy_name; }}

        public static int Enemy_HP
        {
            get { return enemy_HP; }
            set { enemy_HP += value; }
        }

        public static int Enemy_armor
        {
            get { return enemy_armor; }
            set
            {
                enemy_armor += value;

                if (enemy_armor < 0)
                {
                    enemy_armor = 0;
                }
            }
        }

        public static int Enemy_AD
        {
            get { return enemy_AD; }
            set 
            {
                enemy_AD += value;

                if (enemy_AD < 0)
                {
                    enemy_AD = 0;
                }
            }
        }

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
            Level_stats = 10 * Player.Player_level;
        }

        // följande metoder bestämmer fiendens stats
        // OBS! Test data för alla motståndare ändra senare för balancing 
        public static void Goblin()
        {
            enemy_name = "Goblin";
            enemy_HP = 20 + Level_stats;
            enemy_armor = -5 + Level_stats;
            enemy_AD = 10 + Level_stats;
        }
        public static void Orc()
        {
            enemy_name = "Orc";
            enemy_HP = 40 + Level_stats;
            enemy_armor = -2 + Level_stats;
            enemy_AD = 6 + Level_stats;
        }
        public static void Witch()
        {
            enemy_name = "Witch";
            enemy_HP = 15 + Level_stats;
            enemy_armor = 0 + Level_stats;
            enemy_AD = 20 + Level_stats;
        }
        public static void RaidBoss()
        {
            enemy_name = "RaidBoss";
            enemy_HP = 350 + Level_stats;
            enemy_armor = 70 + Level_stats;
            enemy_AD = 120 + Level_stats;
        }
    }
}
