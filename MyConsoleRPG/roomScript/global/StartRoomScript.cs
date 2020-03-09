using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class StartRoomScript:RoomScript
    {
        /// <summary>
        /// 游戏开始界面房间
        /// </summary>
        public override void Runing()
        {
            DeBugRun();
            Console.WriteLine("欢迎来到荒海传说");
            Console.WriteLine();
            Console.WriteLine();
        }
        public override void OutRuning()
        {
            base.OutRuning();
        }
        public override void SetSelect()
        {
            base.SetSelect();
            KeySelects[0] = new KeySelect(Controller.KeyName.NullKey, typeof(Story1_1RoomScript).Name, new StringBuilder().Append("开始新游戏"));
            KeySelects[1] = new KeySelect(Controller.KeyName.NullKey, typeof(OldGameRoomScript).Name, new StringBuilder().Append("继续旧游戏"));
        }
    }
}
