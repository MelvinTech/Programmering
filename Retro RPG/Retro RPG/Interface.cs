using System;

namespace Retro_RPG
{
    public class Interface
    {
        public static void Update_Interface()              // Uppdaterar spelets "interface" med nya siffror och namn
        {
            Console.Clear();                             // raderar alla tecken på skärmen
            Console.SetCursorPosition(0, 0);            // placerar pekaren i översta vänstra hörnet

            Console.WriteLine(" Player: Name: " + Player.Player_Name);  // skriver ut att det är spelaren stats som följer   
            Console.WriteLine(" Level: " + Player.Player_Level);
            Console.Write(" HP: " + Player.Player_HP.ToString() + " | ");       // Skriver ut spelarens hitpoints
            Console.Write(" Armor: " + Player.Player_Armor.ToString() + " | ");     // Skriver ut spelarens armor
            Console.WriteLine(" AD: " + Player.Player_AD.ToString() + " | ");     // Skriver ut spelarens Attack damage

            //Skriver ut fiendens namn och stats
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(" Enemy: Name: " + Enemy.Name);       // skriver ut att det är fiendens stats som följer
            Console.Write(" HP: " + Enemy.HP.ToString() + " | ");      // skriver ut fiendens Hit points
            Console.Write(" Armor: " + Enemy.Armor.ToString() + " | ");      // skriver ut fiendens 
            Console.WriteLine(" AD: " + Enemy.AD.ToString() + " | ");      // skriver ut fiendens attack damage

            Console.SetCursorPosition(0, (Console.WindowHeight - 2));
            Console.WriteLine(" Points: " + Game.Score.ToString());
        }
    }
}
