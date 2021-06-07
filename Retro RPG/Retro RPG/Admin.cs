using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Retro_RPG
{
    /// <summary>
    /// Den här klassen används för att skapa en administrering del av spelet där man kan ändra poäng filerna med mera.
    /// </summary>
    public class Admin
    {
        public Admin() //Används för att starta och skriva ut administratör delen av programmet.
        {
            Console.Clear();
            Game.Cursor_text_pos();
            Console.WriteLine("You are now in admin mode.");
            Game.Cursor_text_pos();
            Console.Write(File.ReadAllText("Textfiler/Admin/Admin.txt"));
            Game.Cursor_standard_pos();

            string command = Console.ReadLine();

            if (command.ToLower() == "scores" )
            {
                Admin_scores();
            }

            else if (command.ToLower() == "return")
            {
                Game.Start();
            }

            else
            {
                new Admin();
            }
        }

        static void Admin_scores() //När command "Scores" ´skriver detta ut alternativen för sparande av poäng.
        {
            Console.Clear();
            Game.Cursor_text_pos();
            Console.WriteLine("Scores");
            Game.Cursor_text_pos();
            Console.Write(File.ReadAllText("Textfiler/Admin/Score.txt"));
            Game.Cursor_standard_pos();

            string command = Console.ReadLine();

            if (command.ToLower() == "clear")
            {
                Score_clear();
            }

            else if (command.ToLower() == "save and clear")
            {
                Score_save();
            }

            else
            {
                new Admin();
            }
        }

        static void Score_clear() //När command "score_clear" används tar den bort filen med highscores 
        {
            File.Delete("Textfiler/Highscore.txt");

            new Admin();
        }

        static void Score_save() //När command "score_save" kallas sparar det först alla gamla poäng i en ny fil i en annan mapp och tar sedan bort filen med highscores.
        {
            string new_text = File.ReadAllText("Textfiler/Highscore.txt");
            string old_text = File.ReadAllText("Textfiler/Oldscores/Scores.txt");

            File.WriteAllText("Textfiler/Oldscores/Scores.txt", old_text + new_text);

            File.Delete("Textfiler/Highscore.txt");

            new Admin();
        }
    }
}
