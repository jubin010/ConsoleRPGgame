using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class WoodStone : Resource
    {
        public WoodStone(int a)
        {
            NoContName = "木灵石";
            InType = InventoryType.stone;
            Amount = a;
        }

        public WoodStone() : this(1)
        {

        }

    
    }
}
