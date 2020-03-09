using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 用于切换使用装备物品的房间脚本
    /// </summary>
    class InventorySwitchRoom:RoomScript
    {
        public InventorySwitchRoom()
        {
            ResultText = new StringBuilder(50);
        }

        /// <summary>
        /// 需要转换的物品
        /// </summary>
        public Inventory SwitchInventory { get; set; }
        public StringBuilder ResultText { get; set; }
        public override void SetSelect()
        {
            KeySelects[0] = new KeySelect(Controller.KeyName.BackKey, GetType().Name, new StringBuilder().Append("返回"));
        }
        public override void Runing()
        {
            ResultText.Clear();
            //只返回玩家物品展示房间
            OutRoom = GameMainRecycle.RoomScripts.Group[typeof(PlayerInventoryRoom).Name];
            KeySelects[0].ToScript = OutRoom.GetType().Name;
            PlayerInventoryRoom room = (PlayerInventoryRoom)OutRoom;

            //需要转换的物品就是物品展示房间选择的物品
            SwitchInventory = GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys[room.SelectIndex];

            //根据不同的物品类，运行不同的转换代码
            switch (SwitchInventory.InType)
            {
                case Inventory.InventoryType.equipment://物品是装备的话
                    Equipment eq = (Equipment)SwitchInventory;
                    GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.RemoveAt(room.SelectIndex);//从物品包中移除该装备
                    switch (eq.EqType)
                    {
                        //装备是武器的话，替换玩家手中的武器为该武器，并将替换下的武器放回物品包
                        case Equipment.EquipmentType.weapon:
                            if( GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon != GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.WeaponEmpty)
                            {
                                ResultText.AppendLine(string.Format("你收起：{0}", GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon.Name));
                                GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Add(GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon);
                            }
                            else
                            {
                                //????

                            }
                            GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon = (Weapon)eq;
                            ResultText.AppendLine(string.Format("装备上了：{0}", GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon.Name));
                            break;
                        default:
                            break;
                    }
                    break;
                case Inventory.InventoryType.funbook://物品是功法书得话
                    FunBook fb = (FunBook)SwitchInventory;
                    bool have = false;
                    foreach (var item in GameMainRecycle.PlayerInfo.PlayerUnit.Functions)
                    {
                        if( item.Name == fb.Name)
                        {
                            have = true;
                        }
                    }
                    if (have)
                    {
                        ResultText.Append("以学习此功法");
                    }
                    else
                    {
                        GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.RemoveAt(room.SelectIndex);
                        GameMainRecycle.PlayerInfo.PlayerUnit.Functions.Add(fb.Fun);
                        ResultText.Append(string.Format("你学习了：{0}", fb.Name));
                    }
                    
                    break;
                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(ResultText);
        }


        public override void OutRuning()
        {

            base.OutRuning();
            OutRoom.RetureRoom = true;
        }
    }
}
