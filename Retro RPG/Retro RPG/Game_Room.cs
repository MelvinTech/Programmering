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
        static int Nr_Paths = 0;
        public Game_Room()
        {
            new Enemy();
            Fight_choice();
        }
        void Fight_choice()
        {
            Console.WriteLine("Do you wish to fight this beast for loot and glory?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No (Lose points for cowardice)");
            string Key =Console.ReadLine();
            
            if ( Key == "1")
            {
                new Fight();
            }
            else if (Key == "2")
            {
                Game.Update();
                new Game_Room();
            }
            else
            {
                Game.Update();
                Fight_choice();
            }
        }

        public static void Battle_Score()
        {
            if (Enemy.Name == "Goblin")
            {
                Game.Score += 10;
            }
            else if (Enemy.Name == "Orc")
            {
                Game.Score += 20;
            }
            else if (Enemy.Name == "Witch")
            {
                Game.Score += 30;
            }
            else if (Enemy.Name == "RaidBoss")
            {
                Game.Score += 2000;
            }
            else
            {
                throw new Exception("Unknown Enemy");
            }
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
            Nr_Paths = Path_Gen.Next(0, 4);

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

            }
        }

        static void Double_Path()
        {

        }

        static void Triple_Path()
        {

        }
    }
}
