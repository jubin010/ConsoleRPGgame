using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class FireStone : Resource
    {
        public FireStone(int a)
        {
            NoContName = "火灵石";
            InType = InventoryType.stone;
            Amount = a;
        }

        public FireStone() : this(1)
        {

        }

    
    }
}
