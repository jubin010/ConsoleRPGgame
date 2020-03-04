using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 单位装备组类，记录单位所装备的所有装备物品
    /// </summary>
    class UnitEquipments
    {
        public Weapon UnitWeapon { get; set; }//单位装备的武器
        public Weapon WeaponEmpty { get; set; }//单位空手时装备的先天武器
        public UnitEquipments()
        {
            WeaponEmpty = new EmptyHanded();
            UnitWeapon = WeaponEmpty;
            
        }
        [Newtonsoft.Json.JsonConstructor]
        public UnitEquipments(Weapon unitWeapon, Weapon weaponEmpty)
        {
            UnitWeapon = unitWeapon;
            WeaponEmpty = weaponEmpty;
        }
    }
}
