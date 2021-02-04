using System;

namespace Retro_RPG
{
    class Combat
    {
        private bool P_Round = false;
        private int damage = 0;

        public Combat()
        {
            new Enemy();
            Game.Update();
            Combat_choice();
        }

        void Combat_choice()
        {
            Game.Cursor_standard_pos();
            Console.WriteLine("Do you wish to fight this beast for loot and glory?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No (Lose points for cowardice)");
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
                Game.Error_message();
                Combat_choice();
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
                Player_round();
            }
            else if (P_Round == true)
            {
                Enemy_round();
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

        void Player_round()
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
                Game.Error_message();
                Player_round();
            }
            Battle();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Enemy_round()
        {
            P_Round = false;
            Random Ac = new Random();
            int num = Ac.Next(1, 5);

            if (num == 1)
            {
                if (Parmor >= EAD)
                {
                    Enemy_round();
                }
            }
            else if (num == 2)
            {
                E_stab();
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

            Battle();
        }

        void E_slice()
        {
            damage = EAD - Parmor;
            Player_damage();
        }
        void E_stab()
        {
            damage = EAD / 2 - Parmor / 4;
            Player_damage();
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

        void P_slice()
        {
            damage = PAD - Earmor;
            Enemy_damage();
        }
        void P_stab()
        {
            damage = PAD / 2 - Earmor / 4;
            Enemy_damage();
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
        void Player_damage()
        {
            if (damage < 0)
            {
                damage = 0;
            }
            Player.Player_HP = -damage;
            Game.Update();
        }
        void Enemy_damage()
        {
            if (damage < 0)
            {
                damage = 0;
            }
            Enemy.Enemy_HP = -damage;
            Game.Update();
        }
    }
}
