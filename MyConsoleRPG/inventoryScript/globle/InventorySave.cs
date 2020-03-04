using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class InventorySave
    {
        public string InventoryName { get; set; }
        public int InventoryCont { get; set; }
        public string JsonString { get; set; }//Json字符组用于转文件
    }
}
