using System;

namespace inline_os
{
    internal class HelpProgram
    {
        internal static void Help()
        {
            Console.Clear();
            string inputfield = "";
            int redcounter = 0;
            int maxred = 10;
            while (inputfield.ToLower() != "exit")
            {
                Console.Title = "Inline OS | Help";
                Console.WriteLine("Welcome to Help!\n" +
                    "you can find any help to do with programs\n" +
                    "to exit, type \"exit\"\n" +
                    "for commands, type \"commands\"");
                Console.Write("HELP> ");
                inputfield = Console.ReadLine();
                if(inputfield.ToLower() == "inline")
                {
                    Console.WriteLine("inline programs are programs that can be run outside of this process but have their output mirrored into this window\n" +
                        "current commands: \"inline gamemanager milkgame\"");
                }
                else if(inputfield.ToLower() == "commands")
                {
                    Console.WriteLine("list of programs:\nhelp, logs, shutdown, [REDACTED], about");
                }
                else if (inputfield.ToLower() == "exit") { }
                else if (inputfield.ToLower() == "redacted")
                {
                    if (redcounter < maxred)
                    {
                        Console.WriteLine("im not telling you");
                        redcounter++;
                    }
                    if(redcounter >= maxred)
                    {
                        Console.Clear();
                        Console.Title = "Inline OS | ALERT!";
                        int i = 0;
                        while(i != 4)
                        {
                            Console.Beep();
                            i++;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.WriteLine("FINE, the command is called \"horny\"\nit'll probably get you banned off school wifi so BE CAREFULL");
                        Console.WriteLine("you have been warned!\npress any key...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ReadLine();
                        inputfield = "exit";
                    }
                }
                else
                {
                    Console.WriteLine("no help avalable for \"{0}\"", inputfield.ToLower());
                }
            }
        }
    }
}