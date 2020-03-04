using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SouthernDoorTile:MapTile
    {
        public SouthernDoorTile()
        {
            TileType = TileTypes.go;
            GoWhere = new GoWhereScript( typeof(SwordSouthValleyMapScript),2,6);
            TileText = "这里是天剑宗南谷入口，由此进入天剑宗南谷镇";
        }

        public override void TileEvent()
        {
            base.TileEvent();
            
        }

    }
}
