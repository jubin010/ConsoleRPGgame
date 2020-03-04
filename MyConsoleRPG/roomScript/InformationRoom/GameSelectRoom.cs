using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏选项房间
    /// </summary>
    class GameSelectRoom : InformationRoomScript
    {
        public int SelectIndex { get; set; }
        public GameSelectRoom()
        {
            SelectText0 = new List<string>(15)
            {
                "人物",
                "物品",
                "任务",
                "返回开始界面",
                "退出保存游戏",
            };
            SelectRoom0 = new List<string>(15)
            {
                typeof(UnitInfoRoom).Name,
                typeof(PlayerInventoryRoom).Name,
                typeof(QuestInfoRoomScript).Name,
                typeof(StartRoomScript).Name,
                typeof(EndRoomScript).Name,
            };

            SelectText1 = new List<string>(15)
            {
                "人物",
                "物品",
                "任务",
                "返回开始界面",
                "退出副本",
            };
            SelectRoom1 = new List<string>(15)
            {
                typeof(UnitInfoRoom).Name,
                typeof(PlayerInventoryRoom).Name,
                typeof(QuestInfoRoomScript).Name,
                typeof(StartRoomScript).Name,
                typeof(OutMazeRoomScript).Name,
            };



        }

        private void SetRoom()
        {
            MapRoomScript mapRoom = (MapRoomScript)LastRoom;
            switch (mapRoom.Script.MapType)
            {
                case MapScript.MapTypes.city:
                    SelectText = SelectText0;
                    SelectRoom = SelectRoom0;
                    break;
                case MapScript.MapTypes.maze:
                    SelectText = SelectText1;
                    SelectRoom = SelectRoom1;
                    break;
                default:
                    break;
            }
        }

        public List<string> SelectText { get; set; }
        public List<string> SelectRoom { get; set; }
        public  List<string> SelectText0 { get; set; }
        public List<string> SelectRoom0 { get; set; }
        public List<string> SelectText1 { get; set; }
        public List<string> SelectRoom1 { get; set; }

        public override void SetSelect()
        {
            

        }
        public override void Runing()
        {
            if (RetureRoom == false)
                SelectIndex = 999;
            SetRoom();
            OutRoom = LastRoom;
            DeBugRun();
            Console.WriteLine("选项：");
            UnitInfoRoom Pinfo = (UnitInfoRoom)  GameMainRecycle.RoomScripts.Group   [SelectRoom[0]];
            Pinfo.Unit = GameMainRecycle.PlayerInfo.PlayerUnit;
            SelectIndex = PrintHelper.PrintSelectText(SelectText, SelectIndex);
            if(SelectIndex <= SelectText.Count)
            {
                OutRoom = GameMainRecycle.RoomScripts.Group[SelectRoom[SelectIndex]];
                OutRoom.LastRoom = this;
            }

        }
    }
}
