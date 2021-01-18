using System;

namespace Retro_RPG
{
    class Fight
    {
        private bool P_Round = false;
        private int Damage = 0;

        public Fight()
        {
            new Enemy();
            Game.Update();
            Fight_choice();
        }

        void Fight_choice()
        {
            Console.WriteLine(" Do you wish to fight this beast for loot and glory?");
            Console.WriteLine(" 1. Yes");
            Console.WriteLine(" 2. No (Lose points for cowardice)");
            string Key = Console.ReadLine();

            if (Key == "1")
            {
                Game.Update();
                Battle();
            }
            else if (Key == "2")
            {
                Game.Score -= 20;
                Game.Update();
                new Game_Room();
            }
            else
            {
                Game.Update();
                Fight_choice();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static int PAD = 0;
        static int Parmor = 0;
        static int EAD = 0;
        static int Earmor = 0;

        void Battle()
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

            else if (P_Round == false)
            {
                Player_Round();
            }
            else if (P_Round == true)
            {
                Enemy_Round();
            }
        }
        public static void Battle_Score()
        {
            string name = Enemy.Enemy_name;

            if (name == "Goblin")
            {
                Game.Score += 10;
                Player.Player_Exp = 10;
            }
            else if (name == "Orc")
            {
                Game.Score += 20;
                Player.Player_Exp = 20;
            }
            else if (name == "Witch")
            {
                Game.Score += 30;
                Player.Player_Exp = 30;
            }
            else if (name == "RaidBoss")
            {
                Game.Score += 2000;
                Player.Player_Exp = 2000;
            }
            else
            {
                throw new Exception("Unknown Enemy");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Player_Round()
        {
            P_Round = true;
            Console.WriteLine("What do you wish to do?");
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
                Console.WriteLine("Command not recognised!");
                Player_Round();
            }
            Battle();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Enemy_Round()
        {
            P_Round = false;
            Random Ac = new Random();
            int num = Ac.Next(0, 5);

            if (num == 1)
            {
                E_Slice();
            }
            else if (num == 2)
            {
                E_Stab();
            }
            else if (num == 3)
            {
                E_Shield();
            }
            else if (num == 4)
            {
                E_Shred();
            }

            Battle();
        }

        void E_Slice()
        {
            Damage = EAD - Parmor;
            Player_Damage();
        }
        void E_Stab()
        {
            Damage = EAD / 2 - Parmor / 4;
            Player_Damage();
        }
        void E_Shield()
        {
            Earmor += 5;
            Game.Update();
        }
        void E_Shred()
        {
            Player.Player_Armor = -20;
        }

        void P_slice()
        {
            Damage = PAD - Earmor;
            Enemy_Damage();
        }
        void P_stab()
        {
            Damage = PAD / 2 - Earmor / 4;
            Enemy_Damage();
        }
        void P_shield()
        {
            Player.Player_Armor = 2;
            Game.Update();
        }
        void P_dodge()
        {
            Player.Player_Armor = 2;
            Game.Update();
        }
        void P_shred()
        {
            Enemy.Enemy_armor -= PAD / 3;
            if (Enemy.Enemy_armor < 0)
            {
                Enemy.Enemy_armor = 0;
            }
            Game.Update();
        }
        void Player_Damage()
        {
            if (Damage < 0)
            {
                Damage = 0;
            }
            Player.Player_HP -= Damage;
            Game.Update();
        }
        void Enemy_Damage()
        {
            if (Damage < 0)
            {
                Damage = 0;
            }
            Enemy.Enemy_HP -= Damage;
            Game.Update();
        }
    }
}
