using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏唯一房间框架类，接受房间脚本，变成不同房间
    /// </summary>
    class GameRoom
    {
        //当前运行的脚本
        public RoomScript Script { get; set; }

        //房间文字显示行字数
        public static int LineLength { get; set; }

        //选项打印行号组
        public List<KeySelect> ActivitySelects { get; set; }

        public GameRoom()
        {
            ActivitySelects = new List<KeySelect>(10);
            LineLength = 30;
            Script = GameMainRecycle.RoomScripts.Group[typeof(StartRoomScript).Name];
        }

        
        public void InRoom()
        {
            Script.Runing();
          
         
                Select();
           
        }

        //按键选择方法，执行于房间脚本之后，用于显示选项，以及触发选项进入对应房间
        public void Select()
        {
            ActivitySelects.Clear();
            bool onlyKey = true;

            foreach (var item in Script.KeySelects)
            {
                if (item != null)
                {
                    //打印房间选项
                    PrintHelper.PrintStoryText(item.PrintSelect(), LineLength);
                    ActivitySelects.Add(item);
                    if (item.Key == Controller.KeyName.NullKey)
                        onlyKey = false;
                    Console.WriteLine();
                }
            }

            //如果不是旧的进入过的房间则将光标移到开头，否则移到末尾
            if (!Script.RetureRoom)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
            }
            if (onlyKey)
                OnlyKeyToSelect();
            else
                SelectToSelect();
        }

        private void SelectToSelect()
        {
            int selectIndex = 0;
            Console.CursorTop = ActivitySelects[selectIndex].PrintLine;
            Console.CursorLeft = 0;
            PrintHelper.PrintWriteColor("=>",ConsoleColor.Red);    //Console.Write();
            Console.SetCursorPosition(0, 0);
            while (true)
            {
                Controller.KeyName kk = Controller.ReadKeyDown();
                switch (kk)
                {
                    case Controller.KeyName.UpKey:
                        Console.CursorTop = ActivitySelects[selectIndex].PrintLine;
                        Console.CursorLeft = 0;
                        Console.Write("  ");
                        selectIndex -= 1;
                        break;
                    case Controller.KeyName.DownKey:
                        Console.CursorTop = ActivitySelects[selectIndex].PrintLine;
                        Console.CursorLeft = 0;
                        Console.Write("  ");
                        selectIndex += 1;
                        break;
                    case Controller.KeyName.LeftKey:      
                    case Controller.KeyName.RightKey:  
                    case Controller.KeyName.BackKey: 
                    case Controller.KeyName.MenuKey:
                        foreach (var item in ActivitySelects)
                        {
                            if( item.Key == kk)
                            {
                                TriggerSelectByType(item);
                                return;
                            }
                        }
                        break;
                    case Controller.KeyName.EnterKey:
                        TriggerSelectByType(ActivitySelects[selectIndex]);
                        return;
                       
                }

                if (selectIndex <= 0)
                    selectIndex = 0;
                if (selectIndex >= ActivitySelects.Count - 1)
                    selectIndex = ActivitySelects.Count - 1;
                Console.CursorTop = ActivitySelects[selectIndex].PrintLine;
                Console.CursorLeft = 0;
                PrintHelper.PrintWriteColor("=>", ConsoleColor.Red);
            }
            
        }

        private void OnlyKeyToSelect()
        {
            while (ActivitySelects.Count > 0)//如果有选项则执行下面按键循环
            {
                Controller.KeyName kk = Controller.ReadKeyDown();
                foreach (var item in Script.KeySelects)
                {
                    if (item != null && item.Key == kk)
                    {
                        TriggerSelectByType(item);
                        return;
                    }
                }
            }
        }

        private void TriggerSelectByType(KeySelect item)
        {
            //将当前房间脚本接下来会执行的脚本引用写入（由按键选项决定）
            Script.OutRoom = GameMainRecycle.RoomScripts.Group[item.ToScript];
            switch (item.TheType)
            {
                case KeySelect.KeySelectType.ToStory:
                    break;
                case KeySelect.KeySelectType.ToMap:
                    //如果按键选项类的类型为指向地图类则如下处理
                    MapRoomScript map = (MapRoomScript)Script.OutRoom;
                    //切换地图重置主角初始位置（根据地图初始信息）
                    if (map.Script != map.MapScripts[item.ToMapScript.Name])
                    {
                        map.Script = map.MapScripts[item.ToMapScript.Name];
                        map.ReLoad();
                    }
                    break;
                case KeySelect.KeySelectType.ToUnit:
                    UnitInfoRoom uu = (UnitInfoRoom)GameMainRecycle.RoomScripts.Group[item.ToScript];
                    uu.Unit = item.Unit;

                    break;
                default:
                    break;
            }
        }

        public RoomScript OutRoom()
        {
            Script.OutRuning();
            Console.Clear();
            if (Script.OutRoom!= null && Script.GiveLast)
            Script.OutRoom.LastRoom = Script;
            return Script.OutRoom;
        }
    }
}
