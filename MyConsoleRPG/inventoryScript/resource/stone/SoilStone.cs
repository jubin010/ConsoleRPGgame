using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SoilStone : Resource
    {
        public SoilStone(int a)
        {
            NoContName = "土灵石";
            InType = InventoryType.stone;
            Amount = a;
        }

        public SoilStone() : this(1)
        {

        }

    
    }
}
