using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Resource : Inventory
    {
        private int _amount;

        public int Amount
        {
            get => _amount;
            set
            {
                if (value >= 0)
                    _amount = value;
                else
                    _amount = 0;
                UpdateName();
            }
        }
        public string NoContName { get; set; }

        private void UpdateName()
        {
            if (Amount != 1)
                Name = string.Format("{1}({0})", Amount, NoContName);
            else if (InType != InventoryType.stone)
                Name = NoContName;
            else
                Name = string.Format("{1}({0})", Amount, NoContName);


        }

        public Resource()
        {
            InType = InventoryType.resource;

        }
    }
}
