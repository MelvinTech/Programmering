using System;

namespace Final_Project
{
    class Game_Room
    {
        public static string Went_Path;
        static int Nr_Paths = 0;

        public Game_Room() // skapar ett nytt rum
        {
            Nr_Path();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Treasure_Room() // Representerar ett nytt rum med en skattkista med poäng
        {
            Random R_Amount = new Random();
            int T_Amount = R_Amount.Next(0, 25) + 10 * Player.Player_Level;

            Game.Update();
            Console.SetCursorPosition(0, 8);
            Game.Score += T_Amount;
            Console.WriteLine("You have entered a treasure room! You found " + T_Amount.ToString() + " Points!");
            Console.ReadKey();

            new Game_Room();
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
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            Console.WriteLine("You can only go forward!");
            Console.WriteLine("1. Go forward");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Went_Path = "Forward";
                In_Room();
            }
            else
            {
                Game.Update();
                Single_Path();
                Console.WriteLine("Unrecognised command, please try again.");
            }
        }

        static void Double_Path()  // det finns två stigar som spelaren kan ta
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            Console.WriteLine(" You can go left and right!");
            Console.WriteLine(" 1. Go left");
            Console.WriteLine(" 2. Go right");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Went_Path = "Left";
                In_Room();
            }
            if (choice == "2")
            {
                Went_Path = "Right";
                In_Room();
            }
            Game.Update();
            Double_Path();
            Console.WriteLine("Unrecognised command, please try again.");
        }

        static void Triple_Path()  // det finns tre stigar som spelaren kan ta
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            Console.WriteLine(" You can go left, right or center");
            Console.WriteLine(" 1. Go forward");
            Console.WriteLine(" 2. Go left");
            Console.WriteLine(" 3. Go right");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Went_Path = "Forward";
                In_Room();
            }
            if (choice == "2")
            {
                Went_Path = "Left";
                In_Room();
            }
            if (choice == "3")
            {
                Went_Path = "right";
                In_Room();
            }
            Game.Update();
            Triple_Path();
            Console.WriteLine("Unrecognised command, please try again.");
        }
        static void In_Room() // väljer vad som finns i rummet
        {
            Game.Update();
            Random random = new Random();
            int encounter = random.Next(1, 4);

            if (encounter == 1)
            {
                new Fight();
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
                throw new Exception("In_Room something is wrong!");
            }
        }
    }
}
