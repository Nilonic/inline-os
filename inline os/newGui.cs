using System;

namespace inline_os
{
    internal class newGui
    {
        internal static void createNewGui()
        {
            NewGuiText button = new NewGuiText("example text uses 4 args", 0, 0, true);
            NewSimpleText button1 = new NewSimpleText("example simple text uses 1 arg");
            NewGuiSystem system = new NewGuiSystem();
            system.init();
            system.add(button);
            system.add(button1);
            system.add(button);
        }
    }

    class NewGuiText
    {
        internal string txt;
        internal bool en;
        /// <summary>
        /// creates a text gui element
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x">how many chars across</param>
        /// <param name="y">how many chars down</param>
        /// <param name="onOneLine">if it should be on one line</param>
        public NewGuiText(string text, int x, int y, bool onOneLine)
        {
            txt = text;
            int xpos = x;
            int ypos = y;
            en = onOneLine;

        }
    }

    class NewSimpleText
    {
        internal string txt;
        /// <summary>
        /// creates a text gui element quickly
        /// </summary>
        /// <param name="text"></param>
        public NewSimpleText(string text)
        {
            txt = "\n" + text;

        }

    }

    class NewGuiSystem
    {
        internal void add(NewGuiText button)
        {
            if (button.en)
            {
                Console.Write(button.txt);
            }
            else
            {
                Console.WriteLine(button.txt);
            }
        }

        internal void add(NewSimpleText button1)
        {
            Console.WriteLine(button1.txt);
        }

        internal void init()
        {
            Console.Clear();
        }
    }

}