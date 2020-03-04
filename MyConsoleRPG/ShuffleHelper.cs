using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// list乱序帮助类
    /// </summary>
    static class ShuffleHelper
    {
        public static void ShuffleList(List<GameUnit> list)
        {
            int len = list.Count;
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = random.Next(len);
                var temp = list[index];
                list[index] = list[i];
                list[i] = temp;
            }
        }

        public static void ShuffleList(List<MapTile.TileLoc> list)
        {
            int len = list.Count;
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = random.Next(len);
                var temp = list[index];
                list[index] = list[i];
                list[i] = temp;
            }
        }

        public static void ShuffleList(List<Card> list)
        {
            int len = list.Count;

            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = random.Next(len);
                var temp = list[index];
                list[index] = list[i];
                list[i] = temp;
            }
        }

        public static void ShuffleList(List<Inventory> list)
        {
            int len = list.Count;
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = random.Next(len);
                var temp = list[index];
                list[index] = list[i];
                list[i] = temp;
            }
        }



    }
}
