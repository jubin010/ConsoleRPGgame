using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 文字打印帮助工具类
    /// </summary>
    static class PrintHelper
    {
        public static int PrintSelectText(List<string> array,int s)
        {
            if(s == 999)
            {
                s = 0;
            }
            int SelectIndex = s;
            if (SelectIndex >= array.Count - 1)
            {
                SelectIndex = array.Count - 1;
            }
            else if (SelectIndex <= 0)
            {
                SelectIndex = 0;
            }

            int line = Console.CursorTop;
            bool goOut = false;
            foreach (var item in array)
            {
                Console.WriteLine("  {0}", item);
            }
            while (array.Count > 0 && goOut == false)
            {
                Console.SetCursorPosition(0, SelectIndex  + line);
                Console.Write("=>");
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, SelectIndex  + line);
                Console.Write("  ");
                switch (key)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        SelectIndex += 1;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        SelectIndex -= 1;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        goOut = true;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        return 999;
                }
                if (SelectIndex >= array.Count - 1)
                {
                    SelectIndex = array.Count - 1;
                }
                else if (SelectIndex <= 0)
                {
                    SelectIndex = 0;
                }

            }
            return SelectIndex;
        }

        public static void PrintStoryText(StringBuilder storyText, int LineLength)
        {
            char[] charsInLine = new char[LineLength];
            int lineStartIndex = 0;

            while (lineStartIndex <= storyText.Length)
            {


                while (true)
                {
                    int kk = storyText.Length - lineStartIndex > LineLength ? LineLength : storyText.Length - lineStartIndex;
                    Array.Clear(charsInLine, 0, charsInLine.Length);
                    storyText.CopyTo(lineStartIndex, charsInLine, 0, kk);
                    int kkk = PrintOneLine(charsInLine);
                    if (kkk >= charsInLine.Length - 1)
                    {
                        break;
                    }
                    lineStartIndex += kkk + 1;
                }

                lineStartIndex += LineLength;
            }


        }

        private static int PrintOneLine(char[] charsInLine)
        {
            for (int i = 0; i < charsInLine.Length; i++)
            {
                Console.Write(charsInLine[i]);
                if (charsInLine[i] == '\n')
                {
                    return i;
                }
                if (i == charsInLine.Length - 1)
                {
                    Console.WriteLine();
                }
            }
            return charsInLine.Length - 1;
        }

        //打印具备颜色的字符串
        public static void PrintWriteColor(string s,ConsoleColor c)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ForegroundColor = BaseColor;

        }

        public static void PrintWriteLineColor(string s, ConsoleColor c)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = BaseColor;
        }

        public static void PrintWriteColor(char s, ConsoleColor c)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ForegroundColor = BaseColor;

        }

        public static void PrintWriteLineColor(char s, ConsoleColor c)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ForegroundColor = BaseColor;
        }
    }
}
