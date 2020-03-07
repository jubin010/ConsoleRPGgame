using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class TestMapDoorTile:MapTile
    {
        public TestMapDoorTile()
        {
            TileType = TileTypes.go;
            GoWhere = new GoWhereScript( typeof(TestMapScript),2,6);
            TileText = "这里去往南谷外广场";
        }

        public override void TileEvent()
        {
            base.TileEvent();
            
        }

    }
}
