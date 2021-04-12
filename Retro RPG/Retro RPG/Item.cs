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
        private static int level_cap = 1;

        public static int Level_cap
        {
            set { level_cap = value; }
        }


        public static string Item_name { get { return item_name; } }
        
        public static int Item_AD { get { return item_AD; } }

        public static int Item_armor { get { return item_armor; } }

        public Item() //Skapar en ny Item av tre förbestämda delar.
        {
            item_AD = 0;
            item_armor = 0;

            Random nr1 = new Random();

            string[] nchoice1 = new string[] {"Rusty ", "Chipped ", "Gleaming "};
            part1 = nchoice1[nr1.Next(0, nchoice1.Length - level_cap)];

            string[] nchoice2 = new string[] {"bronze ", "iron ", "steel "};
            part2 = nchoice2[nr1.Next(0, nchoice2.Length - level_cap)];

            string[] nchoice3 = new string[] {"sword", "axe", "warhammer", "jacket", "chainmail", "platemail" };
            part3 = nchoice3[nr1.Next(0, nchoice3.Length - level_cap)];

            item_name = part1 + part2 + part3;

            Stats();
        }
        private void Stats() //Ger det nya itemet ett antal stats baserat på namnet det fick.
        {
            if (part1 == "Rusty ")
            {
                item_AD += 1;
                item_armor += 1;
            }
            else if (part1 == "Gleaming ")
            {
                item_AD += 8;
                item_armor += 8;
            }
            else
            {
                item_AD += 3;
                item_armor += 3;
            }

            if (part2 == "bronze ")
            {
                item_AD += 1;
                item_armor += 1;
            }
            else if (part2 == "steel ")
            {
                item_AD += 8;
                item_armor += 8;
            }
            else
            {
                item_AD += 2;
                item_armor += 2;
            }
            if (part3 == "sword")
            {
                item_AD += 3;
                item_armor -= 5;
            }
            else if (part3 =="axe")
            {
                item_AD += 3;
                item_armor -= 4;
            }
            else if (part3 == "warhammer")
            {
                item_AD += 5;
                item_armor -= 4;
            }
            else if (part3 == "jacket")
            {
                item_AD -= 4;
                item_armor += 5;
            }
            else if (part3 == "chainmail")
            {
                item_AD -= 3;
                item_armor += 5;
            }
            else if (part3 == "platemail")
            {
                item_AD -= 5;
                item_armor += 8;
            }
        }
    }
}
