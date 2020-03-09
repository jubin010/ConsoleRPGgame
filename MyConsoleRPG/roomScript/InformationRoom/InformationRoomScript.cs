using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 用于展示游戏内事物介绍信息的房间脚本
    /// </summary>
    class InformationRoomScript:RoomScript
    {
        public InformationRoomScript()
        {
            GiveLast = false;
        }

        public override void Runing()
        {
            KeySelects[0].ToScript = LastRoom.GetType().Name;//直接将返回（0号位的选项）选项设定为它来的房间
            DeBugRun();
            //打印介绍信息
            PrintHelper.PrintStoryText(new StringBuilder().Append(GameMainRecycle.InfoText), GameRoom.LineLength);
           
         
        }
        public override void OutRuning()
        {
            base.OutRuning();
            if (LastRoom == OutRoom)//如果返回旧房间
            LastRoom.RetureRoom = true;
            //GameMainRecycle.InfoText = null;//??????
        }
        public override void SetSelect()
        {
            
            KeySelects[0] = new KeySelect(Controller.KeyName.BackKey, GetType() .Name, new StringBuilder().Append("返回"));
        }
    }
}
