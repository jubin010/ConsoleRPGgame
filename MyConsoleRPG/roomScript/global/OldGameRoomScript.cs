using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyConsoleRPG
{
     class OldGameRoomScript : RoomScript
    {
        public KeySelect GoStarRoom { get; set; }
        public OldGameRoomScript()
        {
            GoStarRoom = new KeySelect(Controller.KeyName.BackKey, typeof(StartRoomScript).Name, new StringBuilder().AppendFormat  ("没有存档，请按{0}返回开始房间新建游戏",Controller.ControllerKeys[Controller.KeyName.BackKey].ToString()));
        }

        public override void OutRuning()
        {
            
        }

        public override void SetSelect()
        {
           
        }

        public override void Runing()
        {
            DeBugRun();
            Console.WriteLine("正在加载存档。。。。。。。。");
            string exePath = Directory.GetCurrentDirectory();
            string filePath = string.Format("{0}\\{1}.json", exePath,"Save");

            if (!System.IO.File.Exists(filePath))
            {
                KeySelects[0] = GoStarRoom;
                return;
            }
            else
            {
                KeySelects[0] = null;
                OutRoom = GameMainRecycle.RoomScripts.Group[typeof(MapRoomScript).Name];
                MapRoomScript mapRoom = (MapRoomScript)OutRoom;
                mapRoom.Script = mapRoom.MapScripts[typeof(StartMapScript).Name];
                string j = string.Empty;
                j = JsonHelper.GetMyJson(exePath, "Save");
                PlayerInformation.PlayerSaveDate save = JsonConvert.DeserializeObject<PlayerInformation.PlayerSaveDate>(j);//占用内存高

                mapRoom.Script = mapRoom.MapScripts[save.MapScript];
                mapRoom.X = save.Px;
                mapRoom.Y = save.Py;
                save.SetPlayerDate();

                return;
            }
               

        }

       

    }
}