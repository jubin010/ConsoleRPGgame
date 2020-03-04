using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏选项实例类
    /// </summary>
    class KeySelect
    {
        public enum KeySelectType
        {
            ToStory = 0,
            ToMap = 1,
            ToUnit = 3,
        }
        public KeySelectType TheType { get; set; }
        public ConsoleKey Key { get; set; }
        public string ToScript { get; set; }
        public StringBuilder SelectText { get; set; }

        //将选项字符与选项介绍拼接储存
        public StringBuilder SelectTextAll { get; set; }
        public Type ToMapScript { get; set; }
        public GameUnit Unit { get; set; }

        //创建指向故事类房间的选项实例方法
        /// <summary>
        /// 创建指向故事类房间的选项实例方法（可进入不同故事房间）
        /// </summary>
        /// <param name="k">按键代号</param>
        /// <param name="s">指向的房间脚本名字</param>
        /// <param name="t">选项介绍文字</param>
        public KeySelect(ConsoleKey k,string s,StringBuilder t)
        {
            Key = k;
            SelectText = t;
            ToScript = s;
            SelectTextAll = new StringBuilder();
            ToMapScript = null;
            TheType = KeySelectType.ToStory;
        }

        /// <summary>
        /// 创建指向地图类房间的选项实例方法（只进入地图房间）
        /// </summary>
        /// <param name="k">按键代号</param>
        /// <param name="t">选项介绍文字</param>
        /// <param name="m">指向的地图脚本</param>
        public KeySelect(ConsoleKey k, StringBuilder t,Type m)
        {
            Key = k;
            SelectText = t;
            ToScript = typeof(MapRoomScript).Name;
            SelectTextAll = new StringBuilder();
            ToMapScript = m;
            TheType = KeySelectType.ToMap;
        }

        /// <summary>
        /// 创建指向游戏单位介绍房间的选项实例
        /// </summary>
        /// <param name="k">按键代号</param>
        /// <param name="t">选项介绍</param>
        /// <param name="u">游戏单位实例</param>
        public KeySelect(ConsoleKey k, StringBuilder t, GameUnit u)
        {
            Key = k;
            SelectText = t;
            ToScript = typeof(UnitInfoRoom).Name;
            SelectTextAll = new StringBuilder();
            Unit = u;
            TheType = KeySelectType.ToUnit;
        }

        //将选项字符与选项介绍拼接
        public StringBuilder PrintSelect()
        {
            SelectTextAll.Clear();
            return SelectTextAll.AppendFormat("({0}) {1}", Key, SelectText);   
        }
    }
}
