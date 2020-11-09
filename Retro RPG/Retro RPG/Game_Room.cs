using Microsoft.Win32.SafeHandles;
using System;
using System.Data;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Final_Project
{
    class Game_Room
    {
        public static string Went_Path;
        static int Nr_Paths = 0;
       
        public Game_Room()
        {
            Nr_Path();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Treasure_Room()
        {
            Random R_Amount = new Random();
            int T_Amount = R_Amount.Next(0, 101) + 10 * Player.Player_Level;

            Game.Update();
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("You have entered a treasure room! You found " + T_Amount.ToString() + " Points!");
            Console.ReadLine();

            new Game_Room();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static void Nr_Path()
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
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            Console.WriteLine("You can only go forward!");
            Console.WriteLine("1. Go forward");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Went_Path = "Forward";
                Way();
            }
            else
            {
                Game.Update();
                Single_Path();
                Console.WriteLine("Unrecognised command, please try again.");
            }
        }

        static void Double_Path()
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            Console.WriteLine(" You can go left and right!");
            Console.WriteLine(" 1. Go left");
            Console.WriteLine(" 2. Go right");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Went_Path = "Left";
                Way();
            }
            if (choice == "2")
            {
                Went_Path = "Right";
                Way();
            }
            Game.Update();
            Double_Path();
            Console.WriteLine("Unrecognised command, please try again.");
        }

        static void Triple_Path()
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
                Way();
            }
            if (choice == "2")
            {
                Went_Path = "Left";
                Way();
            }
            if (choice == "3")
            {
                Went_Path = "right";
                Way();
            }
            Game.Update();
            Triple_Path();
            Console.WriteLine("Unrecognised command, please try again.");
        }
        static void Way()
        {
            Game.Update();
            Random random = new Random();
            int encounter = random.Next(0, 4);

            if (encounter == 1)
            {
                new Fight();
            }
            if (encounter == 2)
            {
                Treasure_Room();
            }
            if (encounter == 3)
            {
                new Game_Room();
            }
        }
    }
}
