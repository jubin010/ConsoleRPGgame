using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 所有房间脚本的基类，无实例化
    /// </summary>
    class RoomScript
    {
        //脚本运行结束后将要运行的其他房间脚本
        public RoomScript OutRoom { get; set; }

        //上一个运行过的房间脚本
        public RoomScript LastRoom { get; set; }

        //设定的房间选项空位数
        public int SelectNum { get; set; }

        //存放选项类实例的数组
        public KeySelect[] KeySelects { get; set; }

        //自己是否是被返回的旧房间
        public bool RetureRoom { get; set; }

        //自己是否会变成LastRoom
        public bool GiveLast { get; set; }
        

        public RoomScript()
        {
            GiveLast = true;
            RetureRoom = false;
            SelectNum = 10;
            KeySelects = new KeySelect[ SelectNum];
            SetSelect();

        }

        public void DeBugRun()
        {
            
            Console.WriteLine(GetType().Name);
            //System.Threading.Thread.Sleep(2000);
            //Console.WriteLine(GameMainRecycle.OutGame.ToString());
        }

        /// <summary>
        /// 房间脚本运行方法
        /// </summary>
        public virtual void Runing()
        {

        }

        /// <summary>
        /// 脚本结束运行时最后运行的方法
        /// </summary>
        public virtual void OutRuning()
        {
            RetureRoom = false;
            
        }

        /// <summary>
        /// 初始化设定房间选项，不超过最大选项数SelectNum
        /// </summary>
        public virtual void SetSelect()
        {
            KeySelects[KeySelects.Length - 1] = new KeySelect(Controller.KeyName.BackKey, typeof(NoSaveEndRoomScript).Name,new StringBuilder().Append( "退出游戏"));
        }
       


    }
}
