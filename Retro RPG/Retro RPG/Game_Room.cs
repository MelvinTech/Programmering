using System;
using System.IO;

namespace Retro_RPG
{
    /// <summary>
    /// klassen Game_Room används till att skapa alla rummen i spelet.
    /// </summary>
    class Game_Room
    {
        static int Nr_Paths = 0;
        public static string roomNR;

        public Game_Room() // skapar ett nytt rum
        {
            Random nr = new Random();
            roomNR = nr.Next(1, 7).ToString();

            Nr_Path();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string used_item_name = "Broken dagger";
        private static int used_item_AD;
        private static int used_item_armor;
        private static int damage_up_value = 0;
        private static int defence_up_value = 0;

        public static int Damage_up_value
        {
            get { return damage_up_value; }
            set { damage_up_value = value ; }
        }

        public static int Defence_up_value
        {
            get { return defence_up_value; }
            set { defence_up_value = value; }
        }

        public static void Treasure_Room() // Representerar ett nytt rum med chans att innehålla utrustning eller en powerup.
        {
            Random random1 = new Random();
            int num = random1.Next(1,3);

            if (num == 1) //Kollar ifall numret är lika med 1 vilket betyder att spelaren hittar utrustning.
            {
                new Item();

                Game.Update();
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("When you search the small room you find (a) " + Item.Item_name + ".");
                Console.WriteLine("Do you want to use the item? (You can ony use one item at a time!)");
                Console.WriteLine("\nCurrent item: " + used_item_name);
                Console.WriteLine("Current stats: AD: " + used_item_AD + " armor: " + used_item_armor);

                Console.WriteLine("\nNew item: " + Item.Item_name);
                Console.WriteLine("New stats: AD: " + Item.Item_AD + " armor:" + Item.Item_armor);

                Item_answer();
            }

            if (num == 2) //Kollar ifall numret är lika med två vilket betyder att spelaren hittar en powerup.
            {
                Damage_up_value = random1.Next(5,11);
                Defence_up_value = random1.Next(1, 6);

                if (random1.Next(0,3) == 1)
                {
                    Combat.damage_up = true;
                    Combat.Damage_count = 0;

                    Game.Update();
                    Game.Cursor_text_pos();

                    string text = File.ReadAllText(@"Textfiler/PowerUpRoom/DamageUp.txt"); // Jag använder denna för att på ett enklare sätt skriva ut långa texter
                    Console.WriteLine(text);
                    Console.SetCursorPosition(48 ,Console.WindowHeight / 6);
                    Console.WriteLine("For your next two fights your damage is increased by " + Damage_up_value + ".");
                    Game.Cursor_standard_pos();
                    Console.WriteLine("You can only go one way.");
                    Console.ReadLine();
                }
                else 
                {
                    Combat.defence_up = true;
                    Combat.Defence_count = 0;

                    Game.Update();
                    Game.Cursor_text_pos();

                    string text = File.ReadAllText(@"Textfiler/PowerUpRoom/ArmorUp.txt");
                    Console.WriteLine(text);
                    Console.SetCursorPosition(48, Console.WindowHeight / 4);
                    Console.WriteLine("For your next two fights your defence is increased by " + Defence_up_value + ".");
                    Game.Cursor_standard_pos();
                    Console.WriteLine("You can only go one way.");
                    Console.ReadLine();
                }
                Game.Update();
                new Game_Room();
            }
        }
        private static void Item_answer() //Ser ifall spelaren vill använda utrustningen den hittade eller inte.
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
                Item_answer();
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

        public static void Single_Path() 
        {
            /* 
            Varje _Path representerar ett rum med ett antal utgångar. 
            När ett sådant rum kommer upp skrivs det ut en slumpmässigt vald text som passar in på rummet.
            För att kunna använda ett varierat utbud av texter för varje rum väljer datorn ett slumpmässigt tal mellan 1 - 6 
            som sedan väljer vilken text som skrivs ut. 
            */

            Game.Cursor_text_pos();   

            string text = File.ReadAllText(@"Textfiler/1WayRoom/Room" + roomNR + ".txt");    
            Console.WriteLine(text);

            Game.Cursor_standard_pos();

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

        static void Double_Path()  // Se "Single_Path"
        {
            Game.Cursor_text_pos();

            string text = File.ReadAllText(@"Textfiler/2WayRoom/Room" + roomNR + ".txt");
            Console.WriteLine(text);

            Game.Cursor_standard_pos();
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

        static void Triple_Path()  // Se "Single_Path"
        {
            Game.Cursor_text_pos();

            string text = File.ReadAllText(@"Textfiler/3WayRoom/Room" + roomNR + ".txt");
            Console.WriteLine(text);

            Game.Cursor_standard_pos();
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
