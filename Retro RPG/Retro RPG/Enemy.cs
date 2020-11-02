using System;

namespace Final_Project
{
    public class Enemy
    {
        public static string Name;
        public static int HP = 0;
        public static int Armor =0;
        public static int AD = 0;


        public Enemy()
        {
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

        // följande metoder bestämmer fiendens stats
        // OBS! Test data för alla motståndare ändra senare för balancing 
        public static void Goblin()
        {
            Name = "Goblin";
            HP = 15;
            Armor = 5;
            AD = 10;
        }
        public static void Orc()
        {
            Name = "Orc";
            HP = 30;
            Armor = 12;
            AD = 18;
        }
        public static void Witch()
        {
            Name = "Witch";
            HP = 15;
            Armor = 2;
            AD = 40;
        }
        public static void RaidBoss()
        {
            Name = "RaidBoss";
            HP = 200;
            Armor = 100;
            AD = 60;
        }
    }
}
