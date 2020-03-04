using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class InventoryGroup
    {
        public Dictionary<string, Inventory> Group { get; set; }
        public InventoryGroup()
        {
            Group = new Dictionary<string, Inventory>
            {
                #region 灵石组
                { typeof(GoldStone).Name, new GoldStone() },
                { typeof(WoodStone).Name, new WoodStone() },
                { typeof(WaterStone).Name, new WaterStone() },
                { typeof(FireStone).Name, new FireStone() },
                { typeof(SoilStone).Name, new SoilStone() },
                #endregion

                #region 材料组
                {typeof(Wolfskin).Name,new Wolfskin() },
                #endregion

                #region 功法书
                { typeof(SwordShieldFunBook).Name, new SwordShieldFunBook() },

                #endregion

                #region 武器组
                {typeof(ManMadeWeapon).Name,new ManMadeWeapon() },
                #region 法剑
                {typeof(BaseWoodSword).Name,new BaseWoodSword() },
                #endregion

                #region 命环
                {typeof(EmptyHanded).Name,new EmptyHanded() },
                {typeof(BaseWoodOrcCycle).Name,new BaseWoodOrcCycle() },
                #endregion


                #endregion
            };
        }
    }
}
