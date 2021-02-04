using System;
using System.Threading;

namespace Retro_RPG
{
    class Game_Room
    {
        static int Nr_Paths = 0;

        public Game_Room() // skapar ett nytt rum
        {
            Nr_Path();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string used_item_name = "Broken dagger";
        private static int used_item_AD;
        private static int used_item_armor;

        public static void Treasure_Room() // Representerar ett nytt rum med chans att innehålla utrustning
        {

            new Item();

            Game.Update();
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("When you search the small room you find (a) " + Item.Item_name + ".");
            Console.WriteLine("Do you want to use the item? (You can ony use one item at the same time!)");
            Console.WriteLine("\nCurrent item: " + used_item_name);
            Console.WriteLine("Current stats: AD: " + used_item_AD + " armor: " + used_item_armor);
            
            Console.WriteLine("\nNew item: " + Item.Item_name);
            Console.WriteLine("New stats: AD: " + Item.Item_AD + " armor:" + Item.Item_armor);

            Tanswer();
        }
        private static void Tanswer()
        {
            Game.Cursor_standard_pos();
            Console.WriteLine("\n\n1. Yes \n2. No");
            string ans = Console.ReadLine();

            if (ans == "1")
            {
                int got_AD = Item.Item_AD;
                int got_armor = Item.Item_armor;

                Player.Player_AD = -used_item_AD;
                Player.Player_Armor = -used_item_armor;

                Player.Player_AD = got_AD;
                Player.Player_Armor = got_armor;

                used_item_name = Item.Item_name;
                used_item_AD = got_AD;
                used_item_armor = got_armor;

                Game.Update();

                new Game_Room();
            }
            else if (ans == "2")
            {
                Game.Update();
                new Game_Room();
            }
            else
            {
                Game.Error_message();
                Tanswer();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Nr_Path() // Representerar antalet vägar som spelaren kan gå
        {
            Random Path_Gen = new Random();
            Nr_Paths = Path_Gen.Next(1, 4);

            if (Nr_Paths.Equals(1))
            {
                Single_Path();
            }
            else if (Nr_Paths.Equals(2))
            {
                Double_Path();
            }
            else if (Nr_Paths.Equals(3))
            {
                Triple_Path();
            }

        }

        public static void Single_Path() // det finns en stig som spelaren kan ta
        {
            Game.Cursor_standard_pos();
            Console.WriteLine("You can only go forward!");
            Console.WriteLine("1. Go forward");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                In_Room();
            }
            else
            {
                Game.Update();
                Game.Error_message();
                Single_Path();
            }
        }

        static void Double_Path()  // det finns två stigar som spelaren kan ta
        {
            Game.Cursor_standard_pos();
            Console.WriteLine("You can go left and right!");
            Console.WriteLine("1. Go left");
            Console.WriteLine("2. Go right");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                In_Room();
            }
            else if (choice == "2")
            {
                In_Room();
            }
            else
            {
                Game.Update();
                Game.Error_message();
                Triple_Path();
            }
        }

        static void Triple_Path()  // det finns tre stigar som spelaren kan ta
        {
            Game.Cursor_standard_pos();
            Console.WriteLine("You can go left, right or center");
            Console.WriteLine("1. Go forward");
            Console.WriteLine("2. Go left");
            Console.WriteLine("3. Go right");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                In_Room();
            }
            else if (choice == "2")
            {
                In_Room();
            }
            else if (choice == "3")
            {
                In_Room();
            }
            else
            { 
                Game.Update();
                Game.Error_message();
                Triple_Path();
            }
        }
        static void In_Room() // väljer vad som finns i rummet
        {
            Game.Update();
            Random random = new Random();
            int encounter = random.Next(1, 4);

            if (encounter == 1)
            {
                new Combat();
            }
            else if (encounter == 2)
            {
                Treasure_Room();
            }
            else if (encounter == 3 || encounter == 4)
            {
                new Game_Room();
            }
            else
            {
                throw new Exception("In_Room: something is wrong!");
            }
        }
    }
}
