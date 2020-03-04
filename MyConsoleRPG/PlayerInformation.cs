using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 玩家游戏信息类，记录所有玩家相关的信息
    /// </summary>
    class PlayerInformation
    {
        public class PlayerSaveDate
        {
            public PlayerSaveDate()
            {
                
                Pinventorys = new List<InventorySave>(200);
            }

            public string Pname { get; set; }

            //游戏中修改
            public GameQuest Pquest { get; set; }
            public string MapScript { get; set; }
            public int Px { get; set; }
            public int Py { get; set; }


            public List<Function> PFunctions { get; set; }
            public string Pweapon { get; set; }
            public string JpWeapon { get; set; }
            public List<InventorySave> Pinventorys { get; set; }

            public void GetPlayerDate()
            {
                Pname = GameMainRecycle.PlayerInfo.PlayerUnit.Name;
                Pquest = GameMainRecycle.PlayerInfo.PlayerQuest;
                PFunctions
                    = GameMainRecycle.PlayerInfo.PlayerUnit.Functions;
                if (GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon != GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.WeaponEmpty)
                {
                    if (GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon.GetType().Name == typeof(ManMadeWeapon).Name)
                    {
                        ManMadeWeapon temp = (ManMadeWeapon)GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon;
                        JpWeapon = temp.ToInventorySave().JsonString;
                    }
                    Pweapon = GameMainRecycle.PlayerInfo.PlayerUnit.Equipments.UnitWeapon.GetType().Name;
                }else
                    Pweapon = string.Empty;
                Pinventorys.Clear();
                foreach (var item in GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys)
                {
                    InventorySave insave = new InventorySave();
                    insave.InventoryName = item.GetType().Name;
                    switch (item.InType)
                    {
                        case Inventory.InventoryType.equipment:
                            Equipment eq = (Equipment)item;
                            switch (eq.EqType)
                            {
                                case Equipment.EquipmentType.weapon:
                                    if(item.GetType().Name == typeof(ManMadeWeapon).Name)
                                    {
                                        ManMadeWeapon mw = (ManMadeWeapon)item;
                                        insave = mw.ToInventorySave();
                                    }
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case Inventory.InventoryType.funbook:
                            insave.InventoryCont = 1;
                            break;
                        case Inventory.InventoryType.resource:
                        case Inventory.InventoryType.stone:
                            Resource temp = (Resource)item;
                            insave.InventoryCont = temp.Amount;
                            break;
                        default:
                            break;
                    }

                    Pinventorys.Add(insave);
                }

            }

            public void SetPlayerDate()
            {
               GameMainRecycle.PlayerInfo.PlayerQuest  = Pquest;
                GameUnit Punit = GameMainRecycle.PlayerInfo.PlayerUnit;
                Punit.Name = Pname;
                if (Pweapon != "")
                {
                    if (Pweapon == typeof(ManMadeWeapon).Name)
                    {
                        ManMadeWeapon temp = new ManMadeWeapon();
                        temp.SetManMadeByJson(JpWeapon);
                        Punit.Equipments.UnitWeapon = temp;
                    }else
                        Punit.Equipments.UnitWeapon =(Weapon) GameMainRecycle.Inventorys.Group[Pweapon].Clone();
                }

                Punit.Functions.Clear();
                foreach (var item in PFunctions)
                {
                    Punit.Functions.Add(item);
                } 
                Punit.Inventorys.Clear();
                foreach (var item in Pinventorys)
                {
                    Inventory temp =(Inventory) GameMainRecycle.Inventorys.Group[item.InventoryName].Clone();
                    switch (temp.InType)
                    {
                        case Inventory.InventoryType.equipment:
                            Equipment eq = (Equipment)temp;
                            switch (eq.EqType)
                            {
                                case Equipment.EquipmentType.weapon:
                                    if (item.InventoryName == typeof(ManMadeWeapon).Name)
                                    {
                                        ManMadeWeapon mw = new ManMadeWeapon();
                                        mw.SetManMadeByJson(item.JsonString);
                                        temp = mw;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case Inventory.InventoryType.funbook:
                            break;
                        case Inventory.InventoryType.resource:
                        case Inventory.InventoryType.stone:
                            Resource resource = (Resource)temp;
                            resource.Amount = item.InventoryCont;
                            break;
                        default:
                            break;
                    }
                    Punit.Inventorys.Add( temp);

                }
                
            }

        }




        public   GameUnit PlayerUnit { get; set; }//玩家单位
        public PlayerSaveDate Psave  { get; set; }//玩家存档信息  包含所在城镇位置
        public GameQuest PlayerQuest { get; set; }//接取的玩家任务
        
        public PlayerInformation()
        {
            PlayerUnit = new PlayerUnit();
            //PlayerQuest = new TestQuest();
            Psave = new PlayerSaveDate();
            
        }











        //[Newtonsoft.Json.JsonConstructor]
        //public PlayerInformation(GameUnit playerUnit, PlayerSaveDate pLoc)
        //{
        //    PlayerUnit = playerUnit;
        //    Psave = pLoc;
        //}
    }
}
