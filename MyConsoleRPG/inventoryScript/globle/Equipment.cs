using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Equipment : Inventory
    {
        public enum EquipmentType
        {
            weapon = 0,
        }
        public EquipmentType EqType { get; set; }

        public Equipment()
        {
            InType = InventoryType.equipment;
        }
    }
}
