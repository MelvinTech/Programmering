using System;


namespace Retro_RPG
{
    class Item
    {
        private static string item_name;
        private static int item_AD = 0;
        private static int item_armor = 0;
        private static string part1;
        private static string part2;
        private static string part3;

        public static void Name_set(string name) { item_name = name; }
        public static string Name_get() { return item_name; }
        
        public static int AD_get() { return item_AD; }

        public static int Armor_get() { return item_armor; }
        public Item()
        {
            item_AD = 10;
            item_armor = 10;

            Random nr1 = new Random();

            string[] nchoice1 = new string[] {"Rusty ", "Chipped ", "Gleaming "};
            part1 = nchoice1[nr1.Next(0, nchoice1.Length)];

            string[] nchoice2 = new string[] {"bronze ", "iron ", "steel "};
            part2 = nchoice2[nr1.Next(0, nchoice2.Length)];

            string[] nchoice3 = new string[] {"sword", "axe", "warhammer", "jacket", "chainmail", "platemail" };
            part3 = nchoice3[nr1.Next(0, nchoice3.Length)];

            item_name = part1 + part2 + part3;

            Stats();
        }
        private void Stats()
        {
            if (part1 == "Rusty ")
            {
                item_AD -= 20;
                item_armor -= 20;
            }
            else if (part1 == "Gleaming ")
            {
                item_AD += 30;
                item_armor += 30;
            }
            else
            {
                item_AD -= 10;
                item_armor -= 10;
            }

            if (part2 == "bronze ")
            {
                item_AD -= 20;
                item_armor -= 20;
            }
            else if (part2 == "steel ")
            {
                item_AD += 30;
                item_armor += 30;
            }
            else
            {
                item_AD += 10;
                item_armor += 10;
            }
            if (part3 == "sword")
            {
                item_AD += 5;
                item_armor -= 10;
            }
            else if (part3 =="axe")
            {
                item_AD += 10;
                item_armor -= 15;
            }
            else if (part3 == "warhammer")
            {
                item_AD += 20;
                item_armor -= 30;
            }
            else if (part3 == "jacket")
            {
                item_AD -= 10;
                item_armor += 5;
            }
            else if (part3 == "chainmail")
            {
                item_AD -= 15;
                item_armor += 10;
            }
            else if (part3 == "platemail")
            {
                item_AD -= 30;
                item_armor += 20;
            }
        }
    }
}
