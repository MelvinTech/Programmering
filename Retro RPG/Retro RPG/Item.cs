using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Retro_RPG
{
    class Item
    {
        public static string item_name = "Broken dagger";
        public static int item_AD = 0;
        public static int item_armor = 0;
        private static string part1;
        private static string part2;
        private static string part3;

        public Item()
        {
            item_AD = 10;
            item_armor = 10;

            Random nr1 = new Random();

            string[] nchoice1 = new string[] {"Rusty ", "Chipped ", "Gleaming "};
            part1 = nchoice1[nr1.Next(0, nchoice1.Length)];

            string[] nchoice2 = new string[] {"bronze ", "iron ", "steel "};
            part2 = nchoice2[nr1.Next(0, nchoice2.Length)];

            string[] nchoice3 = new string[] {"sword", "axe", "warhammer", "chainmail", "platemail", "helmet" };
            part3 = nchoice3[nr1.Next(0, nchoice3.Length)];

            item_name = part1 + part2 + part3;

            stats();
        }
        private void stats()
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
        }
    }
}
