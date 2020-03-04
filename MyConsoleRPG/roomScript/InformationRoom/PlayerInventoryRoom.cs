using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 玩家物品包展示房间脚本
    /// </summary>
    class PlayerInventoryRoom:InformationRoomScript
    {
        /// <summary>
        /// 当前选中的物品编号
        /// </summary>
        public int SelectIndex { get; set; }

        //从那个房间打开的背包，用于关闭后返回
        public RoomScript ComeRoom { get; set; }

        public override void SetSelect()
        {
            
           

        }

        public override void Runing()
        {
            
            DeBugRun();
            Console.WriteLine();


            int line = Console.CursorTop;
            if (RetureRoom == false)
            {
                SelectIndex = 0;
                ComeRoom = LastRoom;
            }
            else
            {
                if (SelectIndex+1 > GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count)
                {
                    SelectIndex -= 1;
                }
            }
             
            bool goOut = false;
            
            Console.WriteLine("物品：");
            foreach (var item in GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys)
            {

                Console.WriteLine("  {0}", item.Name);
            }


            while (GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count > 0 && goOut == false)
            {
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(0, SelectIndex + 1 + line);
                Console.Write("=>");
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, SelectIndex + 1 +line);
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
                        OutRoom = GameMainRecycle.RoomScripts.Group[typeof(InverntoryInfoRoom).Name];
                        InverntoryInfoRoom room = (InverntoryInfoRoom)OutRoom;
                        room.SeeInventory = GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys[SelectIndex];
                        room.LastRoom = this;
                        goOut = true;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        OutRoom = ComeRoom;
                        OutRoom.RetureRoom = true;
                        goOut = true;
                        break;
                   


                }
                if (SelectIndex >= GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count - 1)
                {
                    SelectIndex = GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count - 1;
                }
                else if (SelectIndex <= 0)
                {
                    SelectIndex = 0;
                }

            }
            Console.WriteLine("物品栏为空按A返回");
            while (GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count == 0)
            {
                
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.A)
                {
                    OutRoom = ComeRoom;
                    OutRoom.RetureRoom = true;
                    break;
                }
                
            }

           

        }

    }
}
