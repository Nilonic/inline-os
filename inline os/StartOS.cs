using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace inline_os
{
    class StartOS
    {
        public static void Init()
        {
            while (LoggedIn.getLoggedInStatus())
            {
                Console.Title = "Inline OS | IDLE";
                Console.Write("> ");
                var inputfield = Console.ReadLine();
                try
                {
                    if (inputfield.Contains("inline"))
                    {
                        inlineCommandHandler(inputfield.ToLower());
                    }
                    else
                    {
                        commandHandler(inputfield.ToLower());
                    }
                }catch(Exception e)
                {
                    Console.WriteLine("exception {0}", e.GetType());
                }
                finally
                {
                    GC.Collect();
                }
            }
        }

        private static void commandHandler(string v)
        {
            Random random2 = new Random();
            if (v == "help")
            {
                Console.WriteLine("loading HelpProgram()");
                Console.Title = "Inline OS | Running task \"HelpProgram.Help()\", Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                HelpProgram.Help();
            }
            else if(v == "logs")
            {
                Console.WriteLine("loading Logs()");
                Console.Title = "Inline OS | Running task \"Logs.GetLogs()\", Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                Logs.DisplayLogs();
            }
            else if(v == "shutdown" || v == "exit")
            {
                Console.WriteLine("running shutdown script");
                Console.Title = "Inline OS | Running task \"StartOS.BeginShutdownSequence()\", Please Wait";
                Logger.Log("shutdown has begun");
                System.Threading.Thread.Sleep(random2.Next(10000, 15000));
                Console.WriteLine("finished. have a good day!");
                Logger.Log("shutdown has finished");
                Environment.Exit(0);
            }
            else if(v == "horny")
            {
                Console.WriteLine("loading HornyMode()");
                Console.Title = "Inline OS | Running task \"Horny.Hornymode.enable()\", Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.nhentai.com",
                    UseShellExecute = true
                });
                Logger.Log("marked USER as HORNY");
            }
            else if(v == "about")
            {
                Console.WriteLine("Inline OS V1\n" +
                    "started creation on 01/08/22 (dd/mm/yy)\n" +
                    "created to run alongside windows (inline)\n" +
                    "also made to be a locked down version of DOS with (extremely) minimal system requirements\nlegal/system stuff below\n\n\n" +
                    "Licence: Creative Commons\n" +
                    "Memory: " + Program.GetMemory() + "GB\n" +
                    "Current Dir: " + Environment.CurrentDirectory + "\n" +
                    "LogPath: " + Environment.CurrentDirectory + "\\logs\\primarylog.log\n" +
                    "Build Date: 02/08/22 (dd/mm/yy)\n" +
                    "ABOUT MODS [PLEASE READ]\n" +
                    "mods are of the owers responsibility to check through, we will not scan for malitious scripts under ANY CIRCUMSTANCES\n" +
                    "Inline Language Interpreter is as easy to understand as it is to read this wall of text\n" +
                    "YOU HAVE BEEN WARNED!\n" +
                    "press any key [aside from space or tab] to continue");
                Console.ReadLine();
            }
            else if (v == "mods")
            {
                Console.WriteLine("loading ModMenu()");
                Console.Title = "Inline OS | Running task \"modManager.readMods(progname, progcommand);\", Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                Mods.showMods();
            }
            else if (v == "reload")
            {
                Console.WriteLine("running restart script");
                Console.Title = "Inline OS | Running task \"StartOS.BeginRestartSequence()\", Please Wait";
                Logger.Log("restart has begun");
                System.Threading.Thread.Sleep(random2.Next(10000, 15000));
                Logger.Log("restart is now");
                Program.Main(null);
            }
            else if (v == "clear" || v == "cls" || v == "clear console")
            {
                Console.Clear();
            }
            else if (v == "browser")
            {
                Console.WriteLine("loading Browser()");
                Console.Title = "Inline OS | Running SHELL command \"PRAGMA SET PROGRAM {0} INTERNETACCESS {1} HOSTACCESS FALSE\", Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                Browser.mainmenu();
            }
            else if (v == "newgui")
            {
                Console.WriteLine("loading newGui Test");
                Console.Title = "Inline OS | loading newGui TEST V1, Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                newGui.createNewGui();
            }
            else if (v == "muplayer")
            {
                Console.WriteLine("loading MuPlayer");
                Console.Title = "Inline OS | loading MuPlayer, Please Wait";
                System.Threading.Thread.Sleep(random2.Next(1000, 5000));
                MuPlayer.mainMenu();
            }



            else
            {
                Random random = new Random();
                int rand = random.Next(0, 100);
                if (rand < 0.25) //0.25% chance
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID COMMAND DIPSHIT (\"{0}\")", v);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("░░░░░▄▄▄▄▀▀▀▀▀▀▀▀▄▄▄▄▄▄░░░░░░░\n░░░░░█░░░░▒▒▒▒▒▒▒▒▒▒▒▒░░▀▀▄░░░░\n░░░░█░░░▒▒▒▒▒▒░░░░░░░░▒▒▒░░█░░░\n░░░█░░░░░░▄██▀▄▄░░░░░▄▄▄░░░░█░░\n░▄▀▒▄▄▄▒░█▀▀▀▀▄▄█░░░██▄▄█░░░░█░\n█░▒█▒▄░▀▄▄▄▀░░░░░░░░█░░░▒▒▒▒▒░█\n█░▒█░█▀▄▄░░░░░█▀░░░░▀▄░░▄▀▀▀▄▒█\n░█░▀▄░█▄░█▀▄▄░▀░▀▀░▄▄▀░░░░█░░█░\n░░█░░░▀▄▀█▄▄░█▀▀▀▄▄▄▄▀▀█▀██░█░░\n░░░█░░░░██░░▀█▄▄▄█▄▄█▄████░█░░░\n░░░░█░░░░▀▀▄░█░░░█░█▀██████░█░░\n░░░░░▀▄░░░░░▀▀▄▄▄█▄█▄█▄█▄▀░░█░░\n░░░░░░░▀▄▄░▒▒▒▒░░░░░░░░░░▒░░░█░\n░░░░░░░░░░▀▀▄▄░▒▒▒▒▒▒▒▒▒▒░░░░█░\n░░░░░░░░░░░░░░▀▄▄▄▄▄░░░░░░░░█░░");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else //99% chance
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID COMMAND \"{0}\"", v);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        private static void inlineCommandHandler(string iv)
        {
            if (iv.Contains("gamemanager milkgame"))
            {
                Console.Title = "Inline OS | Running task \"EZDllManager().LoadDLL(\"MilkGame.dll\")\", Please Wait";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("EZDllManager V1");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('[');
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("INFO");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] Reading MilkGame.dll...");
                Random random = new Random();
                System.Threading.Thread.Sleep(random.Next(500, 1000));
                Console.WriteLine();
                Console.Write('[');
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("] Could not find MilkGame.Start [Invalid StartPoint]");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID INLINE COMMAND \"{0}\"", iv);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
