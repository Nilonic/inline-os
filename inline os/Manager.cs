using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace inline_os
{
    class Manager
    {
        internal static void ExceptionManager(Exception e)
        {
            Program.crashed = true;
            Random random = new Random();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("an exception occored, Debug info below:\n" +
                "Exception Message: {0}\n" +
                "Stack Trace: {1}\n", e.Message, e.StackTrace);

            Thread.MemoryBarrier();
            Console.WriteLine("running InlineRecoveryAgent.dll");
            System.Threading.Thread.Sleep(random.Next(5000, 10000));
            InlineRecoveryAgent();

        }

        private static void InlineRecoveryAgent()
        {
            Environment.FailFast("Inline OS failed with message \"The method 'InlineRecoveryAgent()' threw an exception:\n" +
    "InlineRecoveryAgent() failed with message \"Invalid KeyPair\"");
        }

        internal static void invokeNewMod(string progname, string progfile, string progcommand, int progversion, string v)
        {
            Program.mods.Add(progname);
            //Console.WriteLine("added name to mods.newMod:{0}", progname);
            Program.modcommands.Add(progcommand);
            //Console.WriteLine("added command to mods.newMod:{0}", progname);
            Program.modfile.Add(progfile);
            //Console.WriteLine("added filepath to mods.newMod:{0}", progname);
            Program.modversion.Add(progversion);
            //Console.WriteLine("added version to mods.newMod:{0}", progname);
            Program.moddirfull.Add(v);
            //Console.WriteLine("added version to mods.newMod:{0}", progname);

            Console.WriteLine("finished execution of mods.newMod:{0}, injecting...", progname);
            System.Threading.Thread.Sleep(2500);
            Console.WriteLine("done!");
        }
    }


}
