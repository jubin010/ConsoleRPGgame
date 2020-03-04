using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore  core = new GameCore();
            bool result = false;


            while (true)
            {
                
                
               result = ThePlayerRound(core);
                
                if (!result)
               result =  TheEnemyRound(core);

                if (result)
                {
                    TheResultRound(core);
                }
            }

           

        }

        private static void TheResultRound(GameCore core)
        {
            Console.Clear();
            PrintUnitData();
            Console.WriteLine(  "游戏结束");
            if (GameCore.PHp == GameCore.EHp)
            {
                Console.WriteLine("平局");
            }else if(GameCore.PHp == 0)
            {
                Console.WriteLine("敌方胜利");
            }
            else
            {
                Console.WriteLine("玩家胜利");
            }
            Console.WriteLine("回合数：{0}", GameCore.Round);
            
            while (true)
            {

            }
        }

        private static bool TheEnemyRound(GameCore core)
        {
            //AI
            core.EnemyCardGroup[GameCore.EnemyRoundCont].RunResult();
            GameCore.EnemyRoundCont += 1;
            GameCore.EnemyRoundCont = GameCore.EnemyRoundCont % core.EnemyCardGroup.Count;
            
            PrintUnitData();
            Console.Write(GameCore.Result.ToString());
            Console.WriteLine();
            Console.WriteLine("敌方回合结束(A)或(左方向键)继续");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    GameCore.Result.Clear();
                    break;
                }
            }
            if (GameCore.PHp <= 0 || GameCore.EHp <= 0)
            {
                return true;
            }else
            return false;
        }

        private static bool   ThePlayerRound(GameCore core)
        {
            //GameCore.Energy = 3;
            GameCore.PShield = 0;
            GameCore.Round += 1;
            int SelectIndex = 0;
            core.DrawCard(5);
            while (core.HandCardGroup.Count > 0)
            {
                PrintUnitData();
                int line = Console.CursorTop;


                bool goOut = false;

                Console.Write("卡牌：");
                Console.SetCursorPosition(20, line);
                //if (core.HandCardGroup[SelectIndex].EnergyCost <= GameCore.Energy)
                Console.WriteLine("描述:"); 
                foreach (var item in core.HandCardGroup)
                {

                    Console.WriteLine("  ({1}){0}", item.Name,item.EnergyCost);
                }


                while (core.HandCardGroup.Count > 0 && goOut == false)
                {
                    Console.SetCursorPosition(0, SelectIndex + 1 + line);
                    Console.Write("=>");
                    Console.SetCursorPosition(22, line + 1);
                    Console.Write("                                                                                                ");
                    Console.SetCursorPosition(22, line + 1);
                    Console.Write(core.HandCardGroup[SelectIndex].Describe);
                    if (core.HandCardGroup[SelectIndex].EnergyCost > GameCore.Energy)
                    {
                        
                        Console.SetCursorPosition(20, line);
                        Console.Write("描述:(灵气不足无法打出)");
                    }
                    else
                    {
                        Console.SetCursorPosition(20, line );
                        Console.Write("描述:                           ");
                    }
                    ConsoleKey key = Console.ReadKey(true).Key;
                    Console.SetCursorPosition(0, SelectIndex + 1 + line);
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
                            goOut = PlayOneCard(core, SelectIndex, goOut);
                            if (GameCore.PHp <= 0 || GameCore.EHp <= 0)
                            {
                                return true;
                            }
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            core.HandCardGroup.Clear();
                            goOut = true;
                            break;


                    }
                    if (SelectIndex >= core.HandCardGroup.Count - 1)
                    {
                        SelectIndex = core.HandCardGroup.Count - 1;
                    }
                    else if (SelectIndex <= 0)
                    {
                        SelectIndex = 0;
                    }


                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
           
            PrintUnitData();
            Console.WriteLine("玩家回合结束(A)或(左方向键)退出");
            while (true )
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
                {
                    break;
                }
            }


            return false;

        }

        private static bool PlayOneCard(GameCore core, int SelectIndex, bool goOut)
        {
            if (core.HandCardGroup[SelectIndex].EnergyCost <= GameCore.Energy)
            {
                GameCore.Energy -= core.HandCardGroup[SelectIndex].EnergyCost;
                core.HandCardGroup[SelectIndex].RunResult();
                core.HandCardGroup.RemoveAt(SelectIndex);
                PrintUnitData();
                Console.Write(GameCore.Result.ToString());
                Console.WriteLine();
                Console.WriteLine("(A)或(左方向键)继续");
                while (true)
                {
                    ConsoleKey key0 = Console.ReadKey(true).Key;
                    if (key0 == ConsoleKey.A || key0 == ConsoleKey.LeftArrow)
                    {
                        break;
                    }
                }
                goOut = true;
                GameCore.Result.Clear();
            }

            return goOut;
        }

        private static void PrintUnitData()
        {
            Console.Clear();
            Console.Write("玩家生命：");
            Console.WriteLine(GameCore.PHp);
            Console.SetCursorPosition(20, 0);
            Console.Write("敌方生命：");
            Console.WriteLine(GameCore.EHp);
            Console.Write("玩家护甲");
            Console.WriteLine(GameCore.PShield);
            Console.SetCursorPosition(20, 1);
            Console.Write("敌方护甲");
            Console.WriteLine(GameCore.EShield);
            Console.Write("玩家能量");
            Console.WriteLine("{0}/{1}",GameCore.Energy,GameCore.MaxEnergy);
            Console.SetCursorPosition(20, 2);
            Console.Write("敌方行为:");
            foreach (var item in GameCore.Selfcore.EnemyCardGroup[GameCore.EnemyRoundCont].CardSkills)
            {
                Console.Write("{0}, ",item.Symbol);
            }
            Console.WriteLine();
            Console.Write("玩家被动:");
            foreach (var item in GameCore.PlayerPerks)
            {
                Console.Write("{0}, ", item.Symbol);
            }
            Console.WriteLine();
            Console.WriteLine("回合数：{0}",GameCore.Round);
            Console.WriteLine();
        }
    }
}

