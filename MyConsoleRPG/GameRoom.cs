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

        public GameRoom()
        {
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
            int nullCont = 0;//用于记录空选项个数
            foreach (var item in Script.KeySelects)
            {
                if (item != null)
                {
                    //打印房间选项
                    PrintHelper.PrintStoryText(item.PrintSelect(), LineLength);
                    Console.WriteLine();
                }
                else
                    nullCont += 1;
            }

            //如果不是旧的进入过的房间则将光标移到开头，否则移到末尾
            if (!Script.RetureRoom)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
            }
            while (Script.KeySelects.Length!=nullCont)//如果有选项则执行下面按键循环
            {
                ConsoleKey kk = Console.ReadKey(true).Key;
                foreach (var item in Script.KeySelects)
                {
                    if(item != null && item.Key == kk)
                    {
                        //将当前房间脚本接下来会执行的脚本引用写入（由按键选项决定）
                        Script.OutRoom =GameMainRecycle.RoomScripts.Group[ item.ToScript];

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
                                UnitInfoRoom uu =(UnitInfoRoom)GameMainRecycle.RoomScripts.Group[item.ToScript];
                                uu.Unit = item.Unit;
                               
                                break;
                            default:
                                break;
                        }
                        return;
                    }
                }
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
