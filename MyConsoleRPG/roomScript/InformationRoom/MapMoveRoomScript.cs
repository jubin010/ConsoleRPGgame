using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 用于地图切换的房间脚本，继承父类介绍房间脚本的介绍功能介绍地图切换点
    /// </summary>
    class MapMoveRoomScript:InformationRoomScript
    {
        public Type GoWhere { get; set; }

        public override void Runing()
        {
            KeySelects[1].ToMapScript = GoWhere;
            base.Runing();
            Console.WriteLine();
            Console.WriteLine();
        }

        public MapMoveRoomScript()
        {
            GoWhere = typeof(StartMapScript);
            //增加了前往的选项
            KeySelects[1] = new KeySelect(ConsoleKey.S,new StringBuilder().Append("前往"),GoWhere);
        }
    }
}
