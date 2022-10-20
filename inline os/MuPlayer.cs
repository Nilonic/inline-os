using System;

namespace inline_os
{
    internal class MuPlayer
    {
        /// <summary>
        /// a music player, please murder me
        /// <example>
        /// should ONLY be called from "StartOS" like this:
        /// <code>
        /// MuPlayer.mainMenu();
        /// </code>
        /// </example>
        /// </summary>
        internal static void mainMenu()
        {
            Console.Clear();
            string inputfield = "";
            while (inputfield.ToLower() != "exit")
            {
                Console.Title = "Inline OS | MuPlayer";
                Console.WriteLine("Welcome to MuPlayer, inline os' homegrown music player!\n" +
                    "music files are stored in {0}\n" +
                    "to exit, type \"exit\"\n" +
                    "for commands, type \"commands\"", Program.musicLocation);
                Console.Write("MuP> ");
                inputfield = Console.ReadLine();
                if (inputfield.ToLower() == "commands")
                {
                    Console.WriteLine("list of programs:\nplay, stop, exit");
                }
                else if (inputfield.ToLower() == "exit") { }
                else
                {
                    Console.WriteLine("invalid command \"{0}\"", inputfield.ToLower());
                }
            }
        }
    }
}