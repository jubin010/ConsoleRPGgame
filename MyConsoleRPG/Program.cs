using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMainRecycle runGame = new GameMainRecycle();
            //调用游戏主循环方法
            runGame.RunRecycle();
        }
    }
}
