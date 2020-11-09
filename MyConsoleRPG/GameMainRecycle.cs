using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏主要逻辑循环类，基于房间的切换实现游戏运行的大多数功能
    /// </summary>
    class GameMainRecycle
    {
    

        
        


        public static bool OutGame { get; set; }
        private bool LoadDone;

        //游戏房间框架，带入不同房间脚本成为不同房间
        public GameRoom Room { get; set; }

        //游戏房间脚本序列
        public static RoomScriptGroup RoomScripts { get; set; }

        //游戏单位序列
        public static NpcUnitGroup NpcUnits { get; set; }

        //游戏物品序列
        public static InventoryGroup Inventorys { get; set; }

        //游戏战斗卡
        public static CardGroup Cards { get; set; }

        //卡技能
        public static SkillGroup Skills { get; set; }
        
        //游戏万物介绍信息
        public static string InfoText { get; set; }

        //玩家游戏信息
        public static PlayerInformation PlayerInfo { get; set; }


        /// <summary>
        /// 单例
        /// </summary>
        public static readonly GameMainRecycle game = new GameMainRecycle();
        private GameMainRecycle()
        {
            OutGame = false;
            LoadDone = false;
            RunLoad();
        }


        private void RunLoad()
        {
            Controller.LoadKeySet();
            Skills = new SkillGroup();
            Cards = new CardGroup();
            Inventorys = new InventoryGroup();
            NpcUnits = new NpcUnitGroup();
            PlayerInfo = new PlayerInformation();
            RoomScripts = new RoomScriptGroup();
            
            
            Room = new GameRoom();
           
            LoadDone = true;
        }
        /// <summary>
        /// 主循环执行方法，循环调用房间脚本切换房间
        /// </summary>
        public  void RunRecycle()
        {
            while (OutGame == false && LoadDone == true)
            {

                Room.InRoom();
                Room.Script = Room.OutRoom();
            }
        }
    }
}
