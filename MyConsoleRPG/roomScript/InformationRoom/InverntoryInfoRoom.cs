using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 用于展示游戏物品的房间脚本
    /// </summary>
    class InverntoryInfoRoom:InformationRoomScript
    {
        public Inventory SeeInventory { get; set; }//需要展示的游戏物品
        public StringBuilder UseText { get; set; }
        private KeySelect GoKey { get; set; }

        public InverntoryInfoRoom()
        {
            UseText = new StringBuilder();
            //占时这样，加一个去往物品装备使用替换房间的选项，如果物品是可以装备展示的话
            GoKey = new KeySelect(Controller.KeyName.EnterKey, typeof(InventorySwitchRoom).Name,UseText);
        }

        

        public override void Runing()
        {
            switch (SeeInventory.InType)
            {
                case Inventory.InventoryType.equipment:
                    UseText.Clear();
                    UseText.Append("装备");
                    KeySelects[1] = GoKey;
                    break;
                case Inventory.InventoryType.funbook:
                    UseText.Clear();
                    UseText.Append("阅读");
                    KeySelects[1] = GoKey;
                    break;
                case Inventory.InventoryType.resource:
                case Inventory.InventoryType.stone:
                    KeySelects[1] = null;
                    break;
                default:
                    break;
            }
            GameMainRecycle.InfoText = SeeInventory.Name;
            base.Runing();

        }

        


    }
}
