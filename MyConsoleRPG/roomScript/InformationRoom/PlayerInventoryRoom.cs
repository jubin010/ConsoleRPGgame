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
                Controller.KeyName key = Controller.ReadKeyDown();
                Console.SetCursorPosition(0, SelectIndex + 1 +line);
                Console.Write("  ");
                switch (key)
                {
                    case Controller.KeyName.UpKey:
                        SelectIndex -= 1;
                        break;
                    case Controller.KeyName.DownKey:
                        SelectIndex += 1;
                        break;
                    case Controller.KeyName.LeftKey:
                        break;
                    case Controller.KeyName.RightKey:
                        break;
                    case Controller.KeyName.EnterKey:
                        OutRoom = GameMainRecycle.RoomScripts.Group[typeof(InverntoryInfoRoom).Name];
                        InverntoryInfoRoom room = (InverntoryInfoRoom)OutRoom;
                        room.SeeInventory = GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys[SelectIndex];
                        room.LastRoom = this;
                        goOut = true;
                        break;
                    case Controller.KeyName.BackKey:
                        OutRoom = ComeRoom;
                        OutRoom.RetureRoom = true;
                        goOut = true;
                        break;
                    case Controller.KeyName.MenuKey:
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
            Console.WriteLine("物品栏为空按<{0}>返回",Controller.ControllerKeys[Controller.KeyName.BackKey]);
            while (GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Count == 0)
            {

                Controller.KeyName key = Controller.ReadKeyDown();
                if (key == Controller.KeyName.BackKey)
                {
                    OutRoom = ComeRoom;
                    OutRoom.RetureRoom = true;
                    break;
                }
                
            }

           

        }

    }
}
