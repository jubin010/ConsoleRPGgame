using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 单位信息展示房间类
    /// </summary>
    class UnitInfoRoom:InformationRoomScript
    {
      

        public GameUnit Unit { get; set; }
        public override void Runing()
        {

            GameMainRecycle.InfoText = Unit.Name;
            base.Runing();
            Console.WriteLine();
            Console.WriteLine("五行: 金({0}), 木({1}), 水({2}), 火({3}), 土({4})",Unit.Gold,Unit.Wood,Unit.Water,Unit.Fire,Unit.Soil);
            Console.WriteLine("武器:{0}", Unit.Equipments.UnitWeapon.Name);
            Console.WriteLine("功法:");
            foreach (var item in Unit.Functions)
            {
                Console.Write("  ");
                Console.WriteLine(item.Name);
                
            }
            Console.WriteLine("卡组:");
            foreach (var item in Unit.UnitCards)
            {
                Console.Write("  ");
                Console.WriteLine(item.Name);

            }


            Console.WriteLine();
            Console.WriteLine();
        }

        public override void OutRuning()
        {
            Unit = null;
            base.OutRuning();

        }
    }
}
