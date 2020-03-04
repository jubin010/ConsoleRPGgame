using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class WaterStone : Resource
    {
        public WaterStone(int a)
        {
            NoContName = "水灵石";
            InType = InventoryType.stone;
            Amount = a;
        }

        public WaterStone() : this(1)
        {

        }

    
    }
}
