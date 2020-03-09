using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MyConsoleRPG
{
    class NoSaveEndRoomScript:RoomScript
    {
        /// <summary>
        /// 游戏结束房间脚本类
        /// </summary>
        public override void Runing()
        {
            DeBugRun();
          
            GameMainRecycle.OutGame = true;
        }
        public override void OutRuning()
        {
            
        }
        public override void SetSelect()
        {
            
        }

       
      


    }
}
