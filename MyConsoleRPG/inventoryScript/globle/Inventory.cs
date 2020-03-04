using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Inventory : ICloneable//克隆接口
    {
        

        public enum InventoryType
        {
            equipment = 0,
            funbook = 1,
            resource = 2,
            stone = 3,
        }
        public InventoryType InType { get; set; }
        public string Name { get; set; }
        



        public Inventory()
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
