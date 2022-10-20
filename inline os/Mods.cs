using System;
using System.Collections.Generic;
using System.IO;

namespace inline_os
{
    internal class Mods
    {
        /// <summary>
        /// checks to see if mod is valid for the version
        /// </summary>
        /// <param name="v">mod to check</param>
        /// <returns>True or False</returns>
        internal static bool CheckIfValidMod(string v)
        {
            if (Program.modsEnabled == true)
            {
                bool result = false;

                int counter = 0;
                int comments = 0;
                bool invalid = false;
                bool invalidfiledir = false;
                string progname = "";
                string progfile = "";
                string progcommand = "";
                int progversion = 0;
                result = true;
                invalid = false;
                invalidfiledir = false;

                // Read the file and display it line by line.  
                try
                {
                    foreach (string line in System.IO.File.ReadLines(v + "\\ModManifest.man"))
                    {
                        if (line.Contains("//"))
                        {
                            comments++;
                        }
                        else
                        {
                            if (line.Contains("ProgramName"))
                            {
                                progname = line.Replace("ProgramName:", "").Trim().ToLower();
                            }
                            if (line.Contains("ProgramFile"))
                            {
                                progfile = line.Replace("ProgramFile:", "").Trim().ToLower();
                            }
                            if (line.Contains("ProgramCommand"))
                            {
                                progcommand = line.Replace("ProgramCommand:", "").Trim().ToLower();
                            }
                            if (line.Contains("ProgramVersion"))
                            {
                                progversion = Int32.Parse(line.Replace("ProgramVersion:", "").Trim().ToLower());
                            }

                            //System.Console.WriteLine(line);
                            counter++;
                        }
                        /*code goes here */
                    }
                }
                catch (Exception)
                {
                    result = false;
                    invalid = true;
                    invalidfiledir = true;
                }
                if (invalid == false)
                {
                    System.Console.WriteLine("There were {0} lines and {1} comment(s)\ninvoking mod {2}", counter, comments, progname);
                    Manager.invokeNewMod(progname, progfile, progcommand, progversion, v);
                }
                else if (invalid == true && invalidfiledir == false)
                {
                    System.Console.WriteLine("There were {0} lines and {1} comment(s), but the file was found invalid", counter, comments);
                }
                else if (invalidfiledir == true)
                {
                    System.Console.WriteLine("The file \"ModManifest\" does not exist, we cannot process the mod \"{0}\".", v.Remove(0, 5));
                }

                return result;
            }
            return false;
        }

        internal static void showMods()
        {
            if (Program.modsEnabled == true)
            {
                Console.Clear();
                string inputfield = "";
                while (inputfield.ToLower() != "exit")
                {
                    Console.Title = "Inline OS | ModManager";
                    Console.WriteLine("Welcome to ModManager V1!\n" +
                        "you can find any mods you've installed here\n" +
                        "to exit, type \"exit\"\n" +
                        "for installed mods, type \"mods\"\n" +
                        "to run a mod, type \"run\"\n" +
                        "to rescan mods, type \"reload\"");
                    Console.Write("MODS> ");
                    inputfield = Console.ReadLine();
                    if (inputfield.ToLower() == "mods")
                    {
                        Console.WriteLine("list of installed mods:");
                        int i123 = 0;
                        while (i123 < Program.modcommands.Count)
                        {
                            Console.Write(Program.modcommands[i123] + "\n");
                            i123++;
                        }
                    }
                    else if (inputfield.ToLower() == "exit") { }
                    else if (inputfield.ToLower() == "reload")
                    {
                        Console.WriteLine("InvokeMods().clearOldMods();");
                        System.Threading.Thread.Sleep(2500);
                        Program.mods.Clear();
                        Program.modcommands.Clear();
                        Program.moddirfull.Clear();
                        Program.modfile.Clear();
                        Program.modversion.Clear();
                        Console.WriteLine("InvokeMods().rescan();");
                        Logger.Log("ModMenu.prg ran InvokeMods().rescan();");
                        System.Threading.Thread.Sleep(2500);
                        Program.LoadMods(Program.modDir);
                    }
                    else if (inputfield.ToLower() == "run")
                    {
                        Console.WriteLine("what mod would you like to run?");
                        int i123 = 0;
                        while (i123 < Program.modcommands.Count)
                        {
                            Console.Write("[{0}] " + Program.modcommands[i123] + "\n", i123);
                            i123++;
                        }
                        int modid = Int32.Parse(Console.ReadLine());
                        string bsdf = Program.modcommands[modid];
                        Console.WriteLine("mod \"{0}\" selected", Program.modcommands[modid]);
                        parseScriptFile(Program.moddirfull[modid], Program.modfile[modid], Program.modDir);
                        Console.WriteLine("mod \"{0}\" finished execution", Program.modcommands[modid]);
                    }
                    else
                    {
                        Console.WriteLine("error, invalid command.");
                    }
                }
            }
            else
            {
                Console.WriteLine("sorry, your sysadmin has disabled mods\n" +
                    "contact your sysadmin for more info");
            }
        }

        private static void parseScriptFile(string modname, string file, string dir)
        {
           List<string> scriptbools = new List<string>();
           List<int> scriptboolsvalue = new List<int>();
            if (Program.modsEnabled == true)
            {
                var filez = File.ReadLines(modname + "/" + file);
                int counter = 0;
                foreach (string line in filez)
                {
                    //System.Console.WriteLine(line);
                    if (line.Contains("//"))
                    {
                        counter++;
                    }
                    else if (line.ToLower().Contains("trace"))
                    {
                        Console.WriteLine(line.Replace("trace ", "").Replace("\"", ""));
                        counter++;
                    }
                    else if (line.ToLower().Contains("clearconsole"))
                    {
                        Console.Clear();
                    }
                    else if (line.ToLower().Contains("ife"))
                    {
                        int mylifeispainandmissury = line.Replace("ife ", "").Length;
                        if (line.Replace("ife ", "").Remove(line.Replace("ife ", "").Length) == line.Replace("ife ", "").Remove(line.Replace("ife ", "").Length + mylifeispainandmissury))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                    }
                    else if (line.ToLower().Contains("new"))
                    {
                        if(line.Replace("new ", "").Contains("ibool"))
                        {
                            scriptbools.Add(line.Replace("new ibool ", "").Remove(line.IndexOf("=")+1));
                            Console.WriteLine("added new bool NAME {0}", scriptbools[scriptbools.Count - 1]);
                            scriptboolsvalue.Add(Int32.Parse(line.Replace("new ibool = " + scriptbools[scriptbools.Count - 1], "")));
                            Console.WriteLine("added new bool NAME {0} with value of {1}", scriptbools[scriptbools.Count - 1], scriptboolsvalue[scriptboolsvalue.Count - 1]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("could not parse mod: Inline_OS.ModManager disabled by SYSADMIN");
            }
        }

        private static string Randombullshitgo()
        {
            var chars = "0123456789ABCDEF";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            finalString = "0x" + finalString;
            return finalString;
        }
    }
}