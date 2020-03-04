using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SouthernSteleTile:MapTile
    {
        public SouthernSteleTile()
        {
            TileChar = '石';
            TileType = TileTypes.info;
            TileText = "一座高大古朴的山门碑，碑上用苍劲的笔法书写着“天剑宗南门”五个大字";
            
        }

       
    }
}
