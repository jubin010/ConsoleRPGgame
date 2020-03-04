using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class GoldStone : Resource
    {
        public GoldStone(int a)
        {
            NoContName = "金灵石";
            
            InType = InventoryType.stone;
            Amount = a;
        }

        public GoldStone() : this(1)
        {

        }

    
    }
}
