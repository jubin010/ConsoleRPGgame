using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class FunBook : Inventory
    {
        public Function Fun { get; set; }
        public FunBook()
        {
            InType = InventoryType.funbook;
            
        }
    }
}
