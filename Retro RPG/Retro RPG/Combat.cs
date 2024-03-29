﻿using System;
using System.IO;

namespace Retro_RPG
{
    /// <summary>
    /// Klassen Combat används till att skapa alla "combats med motståndare."
    /// </summary>
    class Combat
    {
        private bool p_round = false; // Player Round
        public static bool damage_up = false; // berättar ifall damage_up är i effekt eller inte.
        public static bool defence_up = false; // berättar ifall defence_up är i effekt eller inte.
        static int damage_count = 0; // Beskriver hur många gånger som damage_up använts.
        static int defence_count = 0; // Beskriver hur många gånger som defence_up använts.
        private int damage = 0;
        public static string enemyNR; //Berättar vilket nummer som en textfil ska ha.
        private static string enemyname; 

        public static int Damage_count
        {
            set { damage_count = value; }
        }

        public static int Defence_count
        {
            set { defence_count = value; }
        }

        public Combat() //används för att skapa en fight mellan spelaren och en motståndare.
        {
            Random nr = new Random();
            enemyNR = nr.Next(1, 4).ToString();

            new Enemy();

            Game.Update();
            Combat_choice();

            Game.Cursor_text_pos();

            string text = File.ReadAllText(@"Textfiler/" + enemyname + "/" + enemyname + enemyNR + ".txt");
            Console.WriteLine(text);

            Game.Cursor_standard_pos();

            Console.WriteLine("1. You will fight this fiend!");
            Console.WriteLine("2. You shall bravely run away!");
            string Key = Console.ReadLine();

            if (Key == "1")
            {
                Game.Update();
                Battle();
            }
            else if (Key == "2")
            {
                Game.score -= 20;
                Game.Update();
                new Game_Room();
            }
            else
            {
                Game.Update();
                Game.Error_message();
                Combat_choice();
            }
        }

        void Combat_choice() // Bestämmer vilken fiende som spelaren ska möta.
        {
            Game.Cursor_text_pos();

            if (Enemy.Enemy_name == "Goblin")
            {
                enemyname = "Goblin";
            }

            else if (Enemy.Enemy_name == "Orc")
            {
                enemyname = "Orc";
            }

            else if (Enemy.Enemy_name == "Witch")
            {
                enemyname = "Witch";
            }

            else
            {
                if (Player.Player_level > 4)
                {
                    enemyname = "Raidboss";
                    enemyNR = "1";  //Måste sätta en specifik siffra här eftersom raidboss bara har två olika texter en för start och en för slut av fight.
                }
                else
                {
                    new Combat();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static int PAD = 0; //Player attack damage
        static int Parmor = 0; //Player armor
        static int EAD = 0; // Enemy attack damage
        static int Earmor = 0; // Enemy armor

        void Battle() 
            /* Används innan varje runda för att se ifall spelaren har
            förlorat eller vunnit. Om inget utav det är sant väljer den ifall det är spelaren eller motståndarens tur att göra något.*/
        {
            PAD = Player.Player_AD;
            Parmor = Player.Player_Armor;

            EAD = Enemy.Enemy_AD;
            Earmor = Enemy.Enemy_armor;

            if (Enemy.Enemy_HP <= 0)
            {
                Battle_Score();
                new Game_Room();
            }
            else if (Player.Player_HP <= 0)
            {
                Game.Game_Over();
            }

            else if (p_round == false)
            {
                Player_round();
            }
            else if (p_round == true)
            {
                Enemy_round();
            }
        }
        public static void Battle_Score() //Markerar slutet av en runda som spelaren vann. Den räknar ut hur många poäng som spelaren ska få och kollar ifall powerup tiden är slut.
        {
            string name = Enemy.Enemy_name;

            if (damage_up == true)
            {
                damage_count++;
                if (damage_count == 2)
                {
                    damage_up = false;
                    damage_count = 0;
                    Game_Room.Damage_up_value = 0;
                }
            }

            if (defence_up == true)
            {
                defence_count++;
                if (defence_count == 2)
                {
                    defence_up = false;
                    defence_count = 0;
                    Game_Room.Defence_up_value = 0;
                }
            }

            if (name == "Goblin")
            {
                Game.score += 10;
                Player.Player_Exp = 10;
            }
            else if (name == "Orc")
            {
                Game.score += 20;
                Player.Player_Exp = 20;
            }
            else if (name == "Witch")
            {
                Game.score += 30;
                Player.Player_Exp = 30;
            }
            else if (name == "RaidBoss")
            {
                Game.score += 2000;
                Player.Player_Exp = 2000;

                Game.Cursor_text_pos();
                Console.WriteLine(File.ReadAllText("Textfiler/RaidBoss/RaidBoss2"));
                Console.ReadLine();
            }
            else
            {
                throw new Exception("Unknown Enemy Check class 'Enemy'");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Player_round() //Går igenom det spelaren ska göra under varje runda.
        {
            p_round = true;

            if (damage_up == true)
            {
                Console.WriteLine("Pure damage stats: " + Game_Room.Damage_up_value);
            }
            if (defence_up == true)
            {
                Console.WriteLine("Pure defence stats: " + Game_Room.Defence_up_value);
            }

            Game.Cursor_standard_pos();

            Console.WriteLine("\nWhat do you wish to do?");
            Console.WriteLine("1. Slice at enemy");
            Console.WriteLine("2. Stab at enemy");
            Console.WriteLine("3. Raise shield");
            Console.WriteLine("4. Dodge attack");
            Console.WriteLine("5. Shred armor");

            string ans = Console.ReadLine();

            if (ans == "1")
            {
                P_slice();
            }
            else if (ans == "2")
            {
                P_stab();
            }
            else if (ans == "3")
            {
                P_shield();
            }
            else if (ans == "4")
            {
                P_dodge();
            }
            else if (ans == "5")
            {
                P_shred();
            }
            else
            {
                Game.Update();
                Game.Error_message();
                Player_round();
            }
            Battle();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Enemy_round() // Går igenom vad fienden ska göra varje runda.
        {
            p_round = false;
            Random Ac = new Random();
            int num = Ac.Next(1, 5);

            if (num == 1)
            {
                if (EAD > Parmor)                
                {
                    E_slice();
                }
                else
                {
                    Enemy_round();
                }
            }
            else if (num == 2)
            {
                if (EAD / 2 > Parmor / 4)
                {
                    E_stab();
                }
                else
                {
                    Enemy_round();
                }
            }
            else if (num == 3)
            {
                E_shield();
            }
            else if (num == 4)
            {
                if (Player.Player_Armor > 0)
                {
                    E_shred();
                }
                else
                {
                    Enemy_round();
                }
            }
            else
            {
                throw new Exception("Combat:Enemyround: something is wrong!");
            }

            Battle();
        }

        // Följande är alternativ som spelaren eller fienden an välja under en runda.

        void E_slice()
        {
            damage = EAD - Parmor;
            Damage_to_player();
        }
        void E_stab()
        {
            damage = EAD / 2 - Parmor / 4;
            Damage_to_player();
        }
        void E_shield()
        {
            Earmor += 5;
            Game.Update();
        }
        void E_shred()
        {
            Player.Player_Armor = -20;
        }

        //////////////////////////////////////////////////
        
        void P_slice()
        {
            damage = PAD - Earmor;
            Damage_to_enemy();
        }
        void P_stab()
        {
            damage = PAD / 2 - Earmor / 4;
            Damage_to_enemy();
        }
        void P_shield()
        {
            Player.Player_Armor = 8;
            Game.Update();
        }
        void P_dodge()
        {
            Player.Player_Armor = 4;
            Random random1 = new Random();
            int num = random1.Next(0, 2);

            if (num % 2 == 0)
            {
                Game.Update();
                Player_round();
            }

            Game.Update();
        }
        void P_shred()
        {
            Enemy.Enemy_armor = -(PAD / 3);
            Game.Update();
        }
        void Damage_to_player()  //Bestämmer skadan som fienden gör på spelaren.
        {
            if (damage < 0)
            {
                damage = 0;
            }
            Player.Player_HP = -damage + Game_Room.Defence_up_value;
            Game.Update();
        }
        void Damage_to_enemy()  //Bestämmer skadan som spelaren gör mot fienden.
        {
            if (damage < 0)
            {
                damage = 0;
            }
            Enemy.Enemy_HP = -damage - Game_Room.Damage_up_value;
            Game.Update();
        }
    }
}
