using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SouthernForestTile:MapTile
    {
        public SouthernForestTile()
        {
            TileChar = '树';
            TileType = TileTypes.info;
            TileText = "剑南谷南部森林";
            
        }
    }
}
