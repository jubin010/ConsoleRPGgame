﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class MazeTile:MapTile,IEventTile
    {
        public MazeTile()
        {
            TileType = TileTypes.go;
            GoWhere = new GoWhereScript(typeof(SouthValleyMazeScript), 5, 2);
            TileText = "进入南林秘境";
        }

        public void SpecialEvents()
        {
            Console.Clear();
            Console.ReadKey();
        }

        
    }
}
