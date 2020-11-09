using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class MazeMapScript:MapScript
    {
        public MazeMapScript()
        {
            MapType = MapTypes.maze;
        }

        public override void InherentTile()
        {
            base.InherentTile();
            Tiles.Add(new MazeUpDoor());
            Tiles.Add(new MazeDownDoor());
            Tiles.Add(new MazeLeftDoor());
            Tiles.Add(new MazeRightDoor());
            Tiles.Add(new MazeDoorSit());
        }

       
    }
}
