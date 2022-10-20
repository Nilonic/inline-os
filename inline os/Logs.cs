using System;

namespace inline_os
{
    internal class Logs
    {
        internal static void DisplayLogs()
        {
            Console.WriteLine("welcome to logs!");
            try
            {
                string text = System.IO.File.ReadAllText("logs/primarylog.log");
                Console.Clear();
                string inputfield = "";
                string inputfield2 = "";
                while (inputfield.ToLower() != "exit")
                {
                    Console.Title = "Inline OS | Logs";
                    Console.WriteLine("Welcome to Logs!\n" +
                        "this is where programs can display logs\n" +
                        "to exit, type \"exit\"\n" +
                        "to display logs, type \"logs\"\n" +
                        "to add to the log, type append\n");
                    Console.Write("LOGS > ");
                    inputfield = Console.ReadLine();
                    if (inputfield.ToLower() == "logs")
                    {
                        Console.WriteLine(text);
                    }
                    else if (inputfield.ToLower() == "append")
                    {
                        Console.WriteLine("what would you like to append?\n");
                        Console.Write("> ");
                        inputfield2 = Console.ReadLine();
                        Logger.Log("user appended: " + inputfield2);
                        inputfield = "";
                        text = System.IO.File.ReadAllText("logs/primarylog.log");
                    }
                }
            }
            catch(Exception)
            {
                System.IO.Directory.CreateDirectory("logs");
                System.IO.File.Create("logs/primarylog.log");
                System.Threading.Thread.Sleep(500);
                string text = System.IO.File.ReadAllText("logs/primarylog.log");
                Console.Clear();
                string inputfield = "";
                string inputfield2 = "";
                while (inputfield.ToLower() != "exit")
                {
                    Console.Title = "Inline OS | Logs (DEBUG)";
                    Console.WriteLine("Welcome to Logs!\n" +
                        "this is where programs can display logs\n" +
                        "to exit, type \"exit\"\n" +
                        "to display logs, type \"logs\"\n" +
                        "to add to the log, type append\n");
                    Console.Write("LOGS > ");
                    inputfield = Console.ReadLine();
                    if (inputfield.ToLower() == "logs")
                    {
                        if (string.IsNullOrEmpty(text) && string.IsNullOrWhiteSpace(text))
                        {
                            Console.WriteLine("log file empty!");

                        }
                        else
                        {
                            Console.WriteLine(text);
                        }

                    }
                    else if(inputfield.ToLower() == "append")
                    {
                        Console.WriteLine("what would you like to append?\n");
                        Console.Write("> ");
                        inputfield2 = Console.ReadLine();
                        Logger.Log("user appended: " + inputfield2);
                        inputfield = "";
                        text = System.IO.File.ReadAllText("logs/primarylog.log");
                    }
                }
            }

        }
    }
}