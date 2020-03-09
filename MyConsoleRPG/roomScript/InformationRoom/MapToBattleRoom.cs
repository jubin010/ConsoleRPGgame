using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 由地图块进入战斗切换房间
    /// </summary>
    class MapToBattleRoom : InformationRoomScript
    {
        public GameUnit Enemy { get; set; }
        private BattleRoomScript BattleRoom { get; set; }

        public MapToBattleRoom()
        {
            KeySelects[1] = new KeySelect(Controller.KeyName.NullKey, typeof(BattleRoomScript).Name,new StringBuilder().Append("进入战斗"));
            KeySelects[2] = new KeySelect(Controller.KeyName.NullKey, new StringBuilder().Append("查看敌人信息"),Enemy);
        }
        public override void Runing()
        {
            KeySelects[2].Unit = Enemy;
            BattleRoom =(BattleRoomScript) GameMainRecycle.RoomScripts.Group[typeof(BattleRoomScript).Name];
            BattleRoom.LastRoom = LastRoom;
            base.Runing();
            BattleRoom.Enemy = Enemy;
            Console.WriteLine();
            Console.WriteLine();
        }

        public override void OutRuning()
        {
            base.OutRuning();
            if (OutRoom.GetType().Name == typeof(UnitInfoRoom).Name)
            {
                GameMainRecycle.RoomScripts.Group[typeof(UnitInfoRoom).Name].LastRoom = this;
            }
        }
    }
}
