using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace inline_os
{
    internal class Browser
    {
        internal static void mainmenu()
        {
            if (Program.useExperamentalKernel == true)
            {
                Console.WriteLine("is connected = {0}\ncan access = {1}\nbypass? = {2}", checkInternet(), Program.internetEnabled, Program.useExperamentalKernel);
                Console.Clear();
                mainMenu2("http://simple.wikipedia.com");
            }
        }

        private static async void mainMenu2(string v)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var content = await client.GetStringAsync(v);

            Console.WriteLine(Regex.Replace(content, "<.*?>", "\b"));
        }

        private static bool checkInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}