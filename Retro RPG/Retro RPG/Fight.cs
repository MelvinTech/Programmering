using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Final_Project
{
    class Fight
    {
        private bool won = false;
        private bool P_Round = false;
        int Damage = 0;

        public Fight()
        {
            if (won == true)
            {
                Game_Room.Nr_Path();
            }

            Battle();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Battle()
        {
            if (Enemy.HP <= 0)
            {
                Game_Room.Battle_Score();
                won = true;
                if (Enemy.Name == "Goblin")
                {
                    Game.Score += 10;
                    Player.Player_Exp += 20;
                }
                else if (Enemy.Name == "Orc")
                {
                    Game.Score += 20;
                    Player.Player_Exp += 30;
                }
                else if (Enemy.Name == "Witch")
                {
                    Game.Score += 40;
                    Player.Player_Exp += 40;
                }
                else if (Enemy.Name == "Raidboss")
                {
                    Game.Score += 100;
                    Player.Player_Exp += 1000;
                }

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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Player_Round()
        {
            P_Round = true;
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1. Slice at enemy");
            Console.WriteLine("2. Stab at enemy");
            Console.WriteLine("3. Raise shield");
            Console.WriteLine("4. Dodge attack");

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
            else
            {
                Console.Clear();
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
            int num = Ac.Next(0, 4);

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

            Battle();
        }
        void E_Slice()
        {
            Damage = Enemy.AD - Player.Player_Armor;
            Player.Player_HP -= Math.Abs(Damage);
            Game.Update();
        }
        void E_Stab()
        {
            Damage = Enemy.AD / 2 - Player.Player_Armor / 4;
            Player.Player_HP -= Math.Abs(Damage);
            Game.Update();
        }
        void E_Shield()
        {
            Enemy.Armor += 4;
            Game.Update();
        }

        void P_slice()
        {
            Enemy.HP -= Player.Player_AD - Enemy.Armor;
            Game.Update();
        }
        void P_stab()
        {
            Enemy.HP -= Player.Player_AD / 2 - Enemy.Armor / 4;
            Game.Update();
        }
        void P_shield()
        {
            Player.Player_Armor += 5;
            Game.Update();
        }
        void P_dodge()
        {
            Player.Player_Armor += 2;
            Game.Update();
        }

    }
}