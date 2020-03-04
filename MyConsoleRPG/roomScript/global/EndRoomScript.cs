using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MyConsoleRPG
{
    class EndRoomScript:RoomScript
    {
        /// <summary>
        /// 游戏结束房间脚本类
        /// </summary>
        public override void Runing()
        {
            DeBugRun();
            SaveGame();
            GameMainRecycle.OutGame = true;
        }
        public override void OutRuning()
        {
            
        }
        public override void SetSelect()
        {
            
        }

        public void SaveGame()
        {
            GameMainRecycle.PlayerInfo.Psave.GetPlayerDate();
            string Save = Newtonsoft.Json.JsonConvert.SerializeObject(GameMainRecycle.PlayerInfo.Psave);
            //Console.WriteLine( Save );
            string filePath = Directory.GetCurrentDirectory();//获取EXE所在目录
            JsonHelper.SaveMyJson(filePath, Save,"Save");
        }
      


    }
}
