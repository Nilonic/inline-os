using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace inline_os
{
    class Program
    {
        private const int SleepTimeMS = 10000;
        public static string musicLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        public static string musicLocationAlt = "";
        public static List<String> mods = new List<string>();
        public static List<String> moddirfull = new List<string>();
        public static List<String> modcommands = new List<string>();
        public static List<String> modfile = new List<string>();
        public static List<int> modversion = new List<int>();
        public static string modDir = "mods";
        public static bool modsEnabled = true;
        public static string directoryCount = Directory.GetDirectories("mods").Length.ToString();
        public static int loadedDirs = 0;
        public static bool internetEnabled = true;
        public static bool useExperamentalKernel = false;
        public static bool warn = true;
        public static bool useNewGui = false;
        public static int GCCollection = 0;
        public static bool crashed = false;
#nullable enable
        public static void Main(string?[] argv)
        {
            string?[] backupargs = argv;
            try
            {
                for (int i = 0; i < argv.Length; i++)
                {
                    if (argv[i].ToLower() == "-nomods")
                    {
                        Program.modsEnabled = false;
                        Console.WriteLine("mods disabled");
                    }
                    else if (argv[i].ToLower() == "-disableinternet")
                    {
                        Program.internetEnabled = false;
                        Console.WriteLine("internet disabled");
                    }
                    else if (argv[i].ToLower() == "-nowarn")
                    {
                        Program.warn = false;
                        Console.WriteLine("will not warn about experamental features");
                    }
                    else if (argv[i].ToLower() == "-experamentalkernel")
                    {
                        if (Program.warn == true)
                        {
                            Program.useExperamentalKernel = true;
                            Console.WriteLine("Experamental Kernel Activated!\nplease not that this is NOT STABLE");
                        }
                        else
                        {
                            Program.useExperamentalKernel = true;
                            Console.WriteLine("Experamental Kernel Activated");
                        }
                    }
                    else if (argv[i].ToLower() == "-pootis")
                    {
                        Console.Beep();
                        Console.WriteLine("pootis POW HAHA");
                    }
                    else
                    {
                        Console.WriteLine("invalid argument {0}", argv[i]);
                    }
                }
            }
            catch (Exception)
            {

            }
            //Console.Clear();
            bool loggedin = false;
            Console.Title = "Inline OS | Startup";
            Random random = new Random();
            Console.ForegroundColor = ConsoleColor.Green;
            if (Program.useExperamentalKernel == true)
            {
                Console.Write("EZBoot V2");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" BETA \n");
            }
            else
            {
                Console.WriteLine("EZBoot V1");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetMemory() + "GB Of RAM Installed");
            Logger.Log(GetMemory() + "GB Of RAM Installed");
            System.Threading.Thread.Sleep(random.Next(500, 1000));
            Console.WriteLine("Logged Into: " + Environment.UserName + "@" + Environment.MachineName);
            Logger.Log("Logged Into: " + Environment.UserName + "@" + Environment.MachineName);
            System.Threading.Thread.Sleep(random.Next(500, 1000));
            Console.WriteLine(Environment.ProcessorCount + " Logical Processors Detected");
            Logger.Log(Environment.ProcessorCount + " Logical Processors Detected");
            System.Threading.Thread.Sleep(random.Next(500, 1000));
            Console.WriteLine("Is x64: " + Environment.Is64BitOperatingSystem);
            Logger.Log("Is x64: " + Environment.Is64BitOperatingSystem);
            Console.WriteLine("GPU: " + getGPU());
            Logger.Log("GPU: " + getGPU());
            System.Threading.Thread.Sleep(random.Next(500, 1000));
            // If directory does not exist, create it
            if (Program.modsEnabled == true)
            {
                try
                {
                    if (!Directory.Exists(modDir))
                    {
                        Console.Clear();
                        Console.Title = "Inline OS | ModManager V1 : No Mods Folder Detected";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ModManager V1 PreBoot");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCould Not Find \"mods\" folder, will take Path2");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("running function \"CreateAndInvokeMods()\"");
                        Directory.CreateDirectory(modDir);
                        Logger.Log("bootproc.prg ran CreateAndInvokeMods();");
                        LoadMods(modDir);
                    }
                    else
                    {
                        Console.Clear();
                        Console.Title = "Inline OS | ModManager V1 : Mods Folder Detected : " + Program.loadedDirs + " out of " + Program.directoryCount + " loaded";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ModManager V1 PreBoot\n\nFound \"mods\" folder");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Running Function \"InvokeMods()\"");
                        Logger.Log("bootproc.prg ran InvokeMods();");
                        LoadMods(modDir);
                    }
                }
                catch (Exception)
                {
                    Console.Title = "Inline OS | ModManager V1 : No Mods Folder Detected";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ModManager V1 PreBoot");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCould Not Find \"mods\" folder, will take Path2");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("running function \"CreateAndInvokeMods()\"");
                    Directory.CreateDirectory("mods");
                    Logger.Log("bootproc.prg ran CreateAndInvokeMods();");
                }
            }
            System.Threading.Thread.Sleep(random.Next(500, 1000));
            Console.WriteLine();
            loggedin = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Running Function \"InvokeGarbageCollectionLoopback\" with delay of {0}s", SleepTimeMS / 1000);
            Logger.Log("Running Function \"InvokeGarbageCollectionLoopback\" with delay of " + SleepTimeMS / 1000 + "s");
            GC.Collect();
            ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
            {
                while (true)
                {
                    Thread.Sleep(SleepTimeMS);
                    if (crashed)
                    {
                        Console.WriteLine("thread halted!");

                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                        Thread.Sleep(2147483647); //32 bit int limit
                    }
                    GC.Collect();
                    GCCollection++;
                }
            }));
            Console.WriteLine("Ran Function \"InvokeGarbageCollectionLoopback\" with delay of 10s");
            Logger.Log("Ran Function \"InvokeGarbageCollectionLoopback\" with delay of 10s");
            try
            {
                Logger.Log("Logged in!");
                StartOS.Init();
            }
            catch (Exception e)
            {
                Manager.ExceptionManager(e);
            }
        }
#nullable disable
        private static string getGPU()
        {
            ManagementObjectSearcher searcher
     = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        graphicsCard = property.Value.ToString();
                    }
                }
            }
            return graphicsCard;
        }

        public static void LoadMods(string modDir)
        {
            if (Program.modsEnabled == true)
            {
                int i = 0;
                string[] dirlist = Directory.GetDirectories(modDir);
                while (i != dirlist.Length)
                {
                    Console.WriteLine("attempting to load mod " + dirlist[i].Remove(0, 5));
                    if (Mods.CheckIfValidMod(dirlist[i]) == true)
                    {

                    }
                    i++;
                    loadedDirs++;
                    Console.Title = "Inline OS | ModManager V1 : Mods Folder Detected : " + Program.loadedDirs + " out of " + Program.directoryCount + " loaded";
                }
            }
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        public static string GetMemory()
        {
            long memKb;
            GetPhysicallyInstalledSystemMemory(out memKb);
            string finalstring = (memKb / 1024 / 1024).ToString();
            return finalstring;
        }

    }
}
