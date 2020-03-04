using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class MazeUpDoor : MapTile
    {
        public MazeUpDoor()
        {
            TileType = TileTypes.mazeDoor;

        }

        public override void TileEvent()
        {
            GoWhere = new GoWhereScript(InWhere.GetType(), InWhere.Tiles[1].Loc.TileX, InWhere.Tiles[1].Loc.TileY - 1);
            base.TileEvent();
            
        }
    }
}
