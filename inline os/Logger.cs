using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace inline_os
{
    class Logger
    {
        public static void Log(string d)
        {
            string t = DateTime.Now.ToString();
            string b;
            try
            {
                b = System.IO.File.ReadAllText("logs/primarylog.log");
            }catch(Exception)
            {
                System.IO.Directory.CreateDirectory("logs");
                System.Threading.Thread.Sleep(500);
                System.IO.File.Create("logs/primarylog.log");
                System.Threading.Thread.Sleep(500);
                b = System.IO.File.ReadAllText("logs/primarylog.log");
            }
            using (StreamWriter writer = new StreamWriter("logs/primarylog.log"))
            {
                writer.WriteLine("{0}[{1}] {2}", b, t, d);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
