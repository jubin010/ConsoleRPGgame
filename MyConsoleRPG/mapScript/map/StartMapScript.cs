using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class StartMapScript:MapScript
    {
  
        public override void MapSet()
        {
            MapName = "天剑宗南门广场";
            MapChar = new char[,]
             {
                { '、','、','、','、','南','门','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','石','碑','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '林','林','林','林','林','林','林','林','林','林' },

             };
            StarX = 2;
            StarY = 5;

            
        }
        public override void TileSet()
        {
            Tiles.Add(new SouthernForestTile ());
            
            Tiles.Add(new SouthernSteleTile());
           
            Tiles.Add(new SouthernDoorTile());
            TileToMap = new MapTile[,]
            {
                { null,null,null,null,Tiles[2],Tiles[2],null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,Tiles[1],Tiles[1],null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0] },

            };

        }

    }
}
